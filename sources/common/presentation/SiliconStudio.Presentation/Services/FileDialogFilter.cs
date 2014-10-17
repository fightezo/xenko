﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
namespace SiliconStudio.Presentation.Services
{
    /// <summary>
    /// A structure representing a filter for a file dialog.
    /// </summary>
    public struct FileDialogFilter
    {
        /// <summary>
        /// The backing field for the <see cref="Description"/> property.
        /// </summary>
        private readonly string description;
        /// <summary>
        /// The backing field for the <see cref="ExtensionList"/> property.
        /// </summary>
        private readonly string extensionList;

        /// <summary>
        /// Gets the description of this filter.
        /// </summary>
        public string Description { get { return description; } }
        /// <summary>
        /// Gets the list of extensions for this filter, concatenated in a string.
        /// </summary>
        public string ExtensionList { get { return extensionList; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileDialogFilter"/> structure.
        /// </summary>
        /// <param name="description">The description of this filter.</param>
        /// <param name="extensionList">The list of extensions for this filter, concatenated in a string.</param>
        public FileDialogFilter(string description, string extensionList)
        {
            this.description = description;
            this.extensionList = extensionList;
        }
    }
}