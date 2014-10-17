﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;
using System.Diagnostics;
using System.Text;
using SiliconStudio.Core.Collections;

namespace SiliconStudio.Core.Diagnostics
{
    /// <summary>
    /// A logger that stores messages locally useful for internal log scenarios.
    /// </summary>
    [DebuggerDisplay("HasErrors: {HasErrors} Messages: [{Messages.Count}]")]
    public class LoggerResult : Logger, IProgressStatus
    {
        private readonly object loggerLock = new object();

        /// <summary>
        /// Occurs when the progress changed for this logger.
        /// </summary>
        public event EventHandler<ProgressStatusEventArgs> ProgressChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerResult" /> class.
        /// </summary>
        public LoggerResult(string moduleName = null)
        {
            Module = moduleName;
            Messages = new TrackingCollection<ILogMessage>();
            IsLoggingProgressAsInfo = false;
            // By default, all logs are enabled for a local logger.
            ActivateLog(LogMessageType.Verbose);
        }

        /// <summary>
        /// Gets the module name. read-write.
        /// </summary>
        /// <value>The module name.</value>
        public new string Module
        {
            get
            {
                return base.Module;
            }
            set
            {
                base.Module = value;
            }
        }

        /// <summary>
        /// Clears all messages.
        /// </summary>
        public virtual void Clear()
        {
            Messages.Clear();
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is logging progress as information. Default is true.
        /// </summary>
        /// <value><c>true</c> if this instance is logging progress as information; otherwise, <c>false</c>.</value>
        public bool IsLoggingProgressAsInfo { get; set; }

        /// <summary>
        /// Notifies progress on this instance.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Progress(string message)
        {
            OnProgressChanged(new ProgressStatusEventArgs(message));
        }

        /// <summary>
        /// Notifies progress on this instance.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="currentStep">The current step.</param>
        /// <param name="stepCount">The step count.</param>
        public void Progress(string message, int currentStep, int stepCount)
        {
            OnProgressChanged(new ProgressStatusEventArgs(message, currentStep, stepCount));
        }

        /// <summary>
        /// Gets the messages logged to this instance.
        /// </summary>
        /// <value>The messages.</value>
        public TrackingCollection<ILogMessage> Messages { get; private set; }

        protected override void LogRaw(ILogMessage logMessage)
        {
            lock (loggerLock)
            {
                Messages.Add(logMessage);
            }
        }

        /// <summary>
        /// Copies all messages to another instance.
        /// </summary>
        /// <param name="results">The results.</param>
        public void CopyTo(ILogger results)
        {
            foreach (var reportMessage in Messages)
            {
                results.Log(reportMessage);
            }
        }

        /// <summary>
        /// Returns a string representation of this 
        /// </summary>
        /// <returns>System.String.</returns>
        public string ToText()
        {
            var text = new StringBuilder();
            foreach (var logMessage in Messages)
            {
                text.AppendLine(logMessage.ToString());
            }
            return text.ToString();
        }

        private void OnProgressChanged(ProgressStatusEventArgs e)
        {
            if (IsLoggingProgressAsInfo)
            {
                Info(e.Message);
            }

            EventHandler<ProgressStatusEventArgs> handler = ProgressChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        void IProgressStatus.OnProgressChanged(ProgressStatusEventArgs e)
        {
            OnProgressChanged(e);
        }
    }

    /// <summary>
    /// A <see cref="LoggerResult"/> with an associated value;
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LoggerValueResult<T> : LoggerResult
    {
        public LoggerValueResult(string moduleName = null)
            : base(moduleName)
        {
        }

        /// <summary>
        /// Gets or sets the value associated with this log.
        /// </summary>
        /// <value>The value.</value>
        public T Value { get; set; }
    }
}