﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;

namespace SiliconStudio.BuildEngine
{
    [Serializable]
    public struct DatabaseMountInfo
    {
        public string DatabaseMountPoint;

        public DatabaseMountInfo(string databaseMountPoint)
        {
            DatabaseMountPoint = databaseMountPoint;
        }
    }
}