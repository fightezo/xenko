﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using SiliconStudio.Core;

namespace SiliconStudio.Assets
{
    /// <summary>
    /// Type of the project.
    /// </summary>
    [DataContract("ProjectType")]
    public enum ProjectType
    {
        /// <summary>
        /// A library.
        /// </summary>
        Library,

        /// <summary>
        /// An executable.
        /// </summary>
        Executable,

        /// <summary>
        /// A plugin.
        /// </summary>
        Plugin,
    }
}