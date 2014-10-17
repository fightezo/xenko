﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;

namespace SiliconStudio.Core.IO
{
    /// <summary>
    /// Defines a normalized file path. See <see cref="UPath"/> for details. This class cannot be inherited.
    /// </summary>
    [DataContract("UFile")]
    public sealed class UFile : UPath
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UFile"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public UFile(string filePath) : base(filePath, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UPath" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="extension">The extension.</param>
        public UFile(string name, string extension)
            : this(null, null, name, extension)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UPath" /> class.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="name">The name.</param>
        /// <param name="extension">The extension.</param>
        public UFile(string directory, string name, string extension)
            : this(null, directory, name, extension)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UPath" /> class.
        /// </summary>
        /// <param name="drive">The drive.</param>
        /// <param name="directory">The directory.</param>
        /// <param name="name">The name.</param>
        /// <param name="extension">The extension.</param>
        public UFile(string drive, string directory, string name, string extension) : base(drive, directory, name, extension)
        {
        }

        /// <summary>
        /// Gets the file path (<see cref="UPath.GetDirectory()"/> + '/' + <see cref="UFile.GetFileName()"/>) without the extension or drive. Can be an null if no filepath.
        /// </summary>
        /// <returns>The path.</returns>
        public string GetDirectoryAndFileName()
        {
            var span = DirectorySpan;
            if (NameSpan.IsValid)
            {
                span.Length = NameSpan.Next - span.Start;
            }
            return span.IsValid ? FullPath.Substring(span) : null;
        }

        /// <summary>
        /// Gets the name of the file without its extension. Can be null.
        /// </summary>
        /// <returns>The name.</returns>
        public string GetFileName()
        {
            return NameSpan.IsValid ? FullPath.Substring(NameSpan) : null;
        }

        /// <summary>
        /// Gets the extension of the file. Can be null.
        /// </summary>
        /// <returns>The extension.</returns>
        public string GetFileExtension()
        {
            return ExtensionSpan.IsValid ? FullPath.Substring(ExtensionSpan) : null;
        }

        /// <summary>
        /// Gets the name of the file with its extension.
        /// </summary>
        /// <value>The name of file.</value>
        public string GetFileNameWithExtension()
        {
            var span = NameSpan;
            if (ExtensionSpan.IsValid)
            {
                span.Length = ExtensionSpan.Next - span.Start;
            }
            return span.IsValid ? FullPath.Substring(span) : null;
        }

        /// <summary>
        /// Makes this instance relative to the specified anchor directory.
        /// </summary>
        /// <param name="anchorDirectory">The anchor directory.</param>
        /// <returns>A relative path of this instance to the anchor directory.</returns>
        public new UFile MakeRelative(UDirectory anchorDirectory)
        {
            return (UFile)base.MakeRelative(anchorDirectory);
        }

        /// <summary>
        /// Determines whether the specified path is a valid <see cref="UFile"/>
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if the specified path is a valid <see cref="UFile"/>; otherwise, <c>false</c>.</returns>
        public new static bool IsValid(string path)
        {
            if (path == null) throw new ArgumentNullException("path");
            if (!UPath.IsValid(path))
            {
                return false;
            }
            if (path.Length > 0 && path.EndsWith(DirectorySeparatorChar, DirectorySeparatorCharAlt))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="UPath"/>.
        /// </summary>
        /// <param name="fullPath">The full path.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator UFile(string fullPath)
        {
            return fullPath != null ? new UFile(fullPath) : null;
        }
    }
}