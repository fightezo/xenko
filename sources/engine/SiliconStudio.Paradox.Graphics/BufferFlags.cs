﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;
using SiliconStudio.Core;

namespace SiliconStudio.Paradox.Graphics
{
    [Flags]
    [DataContract]
    public enum BufferFlags
    {
        /// <summary>
        /// Creates a none buffer.
        /// </summary>
        /// <remarks>
        /// This is equivalent to <see cref="BindFlags.None"/>.
        /// </remarks>
        None = 0,

        /// <summary>
        /// Creates a constant buffer.
        /// </summary>
        ConstantBuffer = 1,

        /// <summary>
        /// Creates an index buffer.
        /// </summary>
        IndexBuffer = 2,

        /// <summary>
        /// Creates a vertex buffer.
        /// </summary>
        VertexBuffer = 4,

        /// <summary>
        /// Creates a render target buffer.
        /// </summary>
        RenderTarget = 8,

        /// <summary>
        /// Creates a buffer usable as a ShaderResourceView.
        /// </summary>
        ShaderResource = 16,

        /// <summary>
        /// Creates an unordered access buffer.
        /// </summary>
        UnorderedAccess = 32,

        /// <summary>
        /// Creates a structured buffer.
        /// </summary>
        StructuredBuffer = 64,

        /// <summary>
        /// Creates a structured buffer that supports unordered acccess and append.
        /// </summary>
        StructuredAppendBuffer = UnorderedAccess | StructuredBuffer | 128,

        /// <summary>
        /// Creates a structured buffer that supports unordered acccess and counter.
        /// </summary>
        StructuredCounterBuffer = UnorderedAccess | StructuredBuffer | 256,

        /// <summary>
        /// Creates a raw buffer.
        /// </summary>
        RawBuffer = 512,

        /// <summary>
        /// Creates an indirect arguments buffer.
        /// </summary>
        ArgumentBuffer = 1024
    }
}