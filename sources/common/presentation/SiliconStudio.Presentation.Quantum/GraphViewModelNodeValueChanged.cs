﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;

namespace SiliconStudio.Presentation.Quantum
{
    public class GraphViewModelNodeValueChanged : EventArgs
    {
        public GraphViewModelNodeValueChanged(GraphViewModel viewModel, string nodePath)
        {
            ViewModel = viewModel;
            NodePath = nodePath;
        }

        public GraphViewModel ViewModel { get; private set; }

        public string NodePath { get; private set; }
    }
}