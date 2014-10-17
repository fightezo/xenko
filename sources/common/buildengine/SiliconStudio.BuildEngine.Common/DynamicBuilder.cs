﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;
using System.Threading;

using SiliconStudio.Core.Diagnostics;

namespace SiliconStudio.BuildEngine
{
    /// <summary>
    /// This class allow to run a given <see cref="Builder"/> in a new thread. It will run a single <see cref="DynamicBuildStep"/>
    /// that can be fed with a given <see cref="IBuildStepProvider"/>.
    /// </summary>
    public class DynamicBuilder : IDisposable
    {
        /// <summary>
        /// The thread that will run an instance of <see cref="Builder"/> to build provided steps.
        /// </summary>
        private readonly Thread builderThread;
        private readonly Builder builder;
        private readonly DynamicBuildStep dynamicBuildStep;

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicBuilder"/> class.
        /// </summary>
        /// <param name="name">The name of this instance. Used to name the created thread.</param>
        /// <param name="builder">The builder to use.</param>
        /// <param name="buildStepProvider">The build step provider to use.</param>
        public DynamicBuilder(Builder builder, IBuildStepProvider buildStepProvider, string name = null)
        {
            this.builder = builder;
            dynamicBuildStep = new DynamicBuildStep(buildStepProvider);
            builderThread = new Thread(SafeAction.Wrap(BuilderThread)) { IsBackground = true };
            if (!string.IsNullOrEmpty(name))
            {
                builderThread.Name = name;
            }
        }

        /// <summary>
        /// Starts the thread an run the builder.
        /// </summary>
        public void Start()
        {
            builderThread.Start();
        }

        /// <summary>
        /// Cancels any build in progress and wait for the thread to exit.
        /// </summary>
        public void Dispose()
        {
            builder.CancelBuild();
            dynamicBuildStep.NotifyNewWorkAvailable();
            builderThread.Join();
        }

        /// <summary>
        /// Notify the <see cref="DynamicBuildStep"/> that a new build step is available.
        /// </summary>
        public void NotifyBuildStepAvailable()
        {
            dynamicBuildStep.NotifyNewWorkAvailable();
        }

        private void BuilderThread()
        {
            builder.Reset();
            builder.Root.Add(dynamicBuildStep);
            builder.Run(Builder.Mode.Build, true, false);
        }
    }
}