﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
#if SILICONSTUDIO_PARADOX_GRAPHICS_API_NULL 
using System;

namespace SiliconStudio.Paradox.Graphics
{
    public partial class SamplerState
    {
        private SamplerState(GraphicsDevice graphicsDevice, SamplerStateDescription samplerStateDescription)
        {
            throw new NotImplementedException();
        }
    }
} 
#endif 
