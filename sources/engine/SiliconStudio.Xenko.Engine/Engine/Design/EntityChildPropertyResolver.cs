﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.

using System;
using System.Reflection;
using SiliconStudio.Core;
using SiliconStudio.Core.Reflection;
using SiliconStudio.Xenko.Updater;

namespace SiliconStudio.Xenko.Engine.Design
{
    class EntityChildPropertyResolver : UpdateMemberResolver
    {
        [ModuleInitializer]
        internal static void __Initialize__()
        {
            UpdateEngine.RegisterMemberResolver(new EntityChildPropertyResolver());
        }

        public override Type SupportedType
        {
            get { return typeof(Entity); }
        }

        public override UpdatableMember ResolveProperty(string propertyName)
        {
            return new EntityChildPropertyAccessor(propertyName);
        }

        public override UpdatableMember ResolveIndexer(string indexerName)
        {
            var dotIndex = indexerName.LastIndexOf('.');
            if (dotIndex == -1)
                return null;

            // TODO: Temporary hack to get static field of the requested type/property name
            // Need to have access to DataContract name<=>type mapping in the runtime (only accessible in SiliconStudio.Core.Design now)
            var type = AssemblyRegistry.GetType(indexerName.Substring(0, dotIndex));
            var field = type.GetRuntimeField(indexerName.Substring(dotIndex + 1));

            return new EntityComponentPropertyAccessor((PropertyKey)field.GetValue(null));
        }

        class EntityChildPropertyAccessor : UpdatableCustomAccessor
        {
            private readonly string childName;

            public EntityChildPropertyAccessor(string childName)
            {
                this.childName = childName;
            }

            /// <inheritdoc/>
            public override Type MemberType => typeof(Entity);

            /// <inheritdoc/>
            public override void GetBlittable(IntPtr obj, IntPtr data)
            {
                throw new NotSupportedException();
            }

            /// <inheritdoc/>
            public override void SetBlittable(IntPtr obj, IntPtr data)
            {
                throw new NotSupportedException();
            }

            /// <inheritdoc/>
            public override void SetStruct(IntPtr obj, object data)
            {
                throw new NotSupportedException();
            }

            /// <inheritdoc/>
            public override IntPtr GetStructAndUnbox(IntPtr obj, object data)
            {
                throw new NotSupportedException();
            }

            /// <inheritdoc/>
            public override object GetObject(IntPtr obj)
            {
                var entity = UpdateEngineHelper.PtrToObject<Entity>(obj);
                foreach (var child in entity.Transform.Children)
                {
                    var childEntity = child.Entity;
                    if (childEntity.Name == childName)
                    {
                        return childEntity;
                    }
                }

                // TODO: Instead of throwing an exception, we could just skip it
                // If we do that, we need to add how many entries to skip in the state machine
                throw new InvalidOperationException(string.Format("Could not find child entity named {0}", childName));
            }

            /// <inheritdoc/>
            public override void SetObject(IntPtr obj, object data)
            {
                throw new NotSupportedException();
            }
        }

        private class EntityComponentPropertyAccessor : UpdatableCustomAccessor
        {
            private readonly PropertyKey propertyKey;

            public EntityComponentPropertyAccessor(PropertyKey propertyKey)
            {
                this.propertyKey = propertyKey;
            }

            /// <inheritdoc/>
            public override Type MemberType => propertyKey.PropertyType;

            /// <inheritdoc/>
            public override void GetBlittable(IntPtr obj, IntPtr data)
            {
                throw new NotSupportedException();
            }

            /// <inheritdoc/>
            public override void SetBlittable(IntPtr obj, IntPtr data)
            {
                throw new NotSupportedException();
            }

            /// <inheritdoc/>
            public override void SetStruct(IntPtr obj, object data)
            {
                throw new NotSupportedException();
            }

            /// <inheritdoc/>
            public override IntPtr GetStructAndUnbox(IntPtr obj, object data)
            {
                throw new NotSupportedException();
            }

            /// <inheritdoc/>
            public override object GetObject(IntPtr obj)
            {
                var entity = UpdateEngineHelper.PtrToObject<Entity>(obj);
                return entity.Components[propertyKey];
            }

            /// <inheritdoc/>
            public override void SetObject(IntPtr obj, object data)
            {
                var entity = UpdateEngineHelper.PtrToObject<Entity>(obj);
                entity.Components[propertyKey] = data;
            }
        }
    }
}