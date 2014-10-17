﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System.Collections.Generic;

using SiliconStudio.Assets;
using SiliconStudio.Assets.Compiler;
using SiliconStudio.Core;
using SiliconStudio.Paradox.Engine.Data;

namespace SiliconStudio.Paradox.Assets.Physics
{
    [DataContract("ColliderShapeAsset")]
    [AssetFileExtension(FileExtension)]
    [AssetCompiler(typeof(ColliderShapeAssetCompiler))]
    [AssetFactory(typeof(ColliderShapeFactory))]
    [AssetDescription("Collider Shape", "A physics collider shape", false)]
    public class ColliderShapeAsset : Asset
    {
        public const string FileExtension = ".pdxphy";

        public ColliderShapeAsset()
        {
            Data = new PhysicsColliderShapeData();
        }

        [DataMember(10)]
        public PhysicsColliderShapeData Data { get; set; }

        private class ColliderShapeFactory : IAssetFactory
        {
            public Asset New()
            {
                return new ColliderShapeAsset();
            }
        }
    }
}
