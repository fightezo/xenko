﻿using System;
using System.Collections.Generic;
using SiliconStudio.Core;
using SiliconStudio.Core.Serialization.Assets;
using SiliconStudio.Xenko.Graphics;

namespace SiliconStudio.Xenko.Rendering
{
    /// <summary>
    /// Entry-point for implementing rendering feature.
    /// </summary>
    public abstract class RenderFeature : ComponentBase, IGraphicsRendererCore
    {
        protected RenderContext Context { get; private set; }

        public NextGenRenderSystem RenderSystem { get; internal set; }

        public bool Initialized { get; private set; }

        public bool Faulted { get; private set; }

        public bool Enabled { get { return true; } set { throw new NotImplementedException(); } }

        public void Initialize(RenderContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            if (Context != null)
                throw new InvalidOperationException("RenderFeature already initialized");

            Context = context;

            try
            {
                InitializeCore();
            }
            catch (Exception)
            {
                Faulted = true;
            }

            Initialized = true;

            // Notify that a particular renderer has been initialized.
            context.OnRendererInitialized(this);
        }

        /// <summary>
        /// Initializes this instance.
        /// Query for specific cbuffer (either new one, like PerMaterial, or parts of an existing one, like PerObject=>Skinning)
        /// </summary>
        protected virtual void InitializeCore()
        {
        }

        /// <summary>
        /// Extract data from entities, should be as fast as possible to not block simulation loop. It should be mostly copies, and the actual processing should be part of Prepare().
        /// </summary>
        public virtual void Extract()
        {
        }

        /// <summary>
        /// Perform effect permutations, before <see cref="Prepare"/>.
        /// </summary>
        public virtual void PrepareEffectPermutations()
        {
        }

        /// <summary>
        /// Can perform much more work, even while game simulation keeps running.
        /// </summary>
        /// <param name="context"></param>
        public virtual void Prepare(RenderThreadContext context)
        {
        }

        /// <summary>
        /// Performs GPU updates and/or draw.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="renderView"></param>
        /// <param name="renderViewStage"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        public virtual void Draw(RenderDrawContext context, RenderView renderView, RenderViewStage renderViewStage, int startIndex, int endIndex)
        {
        }
    }
}