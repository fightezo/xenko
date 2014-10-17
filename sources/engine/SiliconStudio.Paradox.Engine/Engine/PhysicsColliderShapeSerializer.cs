﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;

using SiliconStudio.Core.Serialization;
using SiliconStudio.Paradox.Engine.Data;

namespace SiliconStudio.Paradox.Engine
{
    public class PhysicsColliderShapeSerializer : DataSerializer<PhysicsColliderShape>, IDataSerializerInitializer
    {
        public override void Serialize(ref PhysicsColliderShape obj, ArchiveMode mode, SerializationStream stream)
        {
            throw new NotImplementedException();
        }

        public void Initialize(SerializerSelector serializerSelector)
        {
            throw new NotImplementedException();
        }
    }
}
