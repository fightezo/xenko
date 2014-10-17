// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;

namespace SiliconStudio.Presentation.ViewModel
{
    public class DirtinessChangedEventArgs : EventArgs
    {
        public DirtinessChangedEventArgs(bool newValue)
        {
            IsDirty = newValue;
        }

        public bool IsDirty { get; private set; }
    }
}