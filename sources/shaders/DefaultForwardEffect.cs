// <auto-generated>
// Do not edit this file yourself!
//
// This code was generated by Paradox Shader Mixin Code Generator.
// To generate it yourself, please install SiliconStudio.Paradox.VisualStudio.Package .vsix
// and re-save the associated .pdxfx.
// </auto-generated>

using SiliconStudio.Core;
using SiliconStudio.Paradox.Effects;
using SiliconStudio.Paradox.Shaders;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Graphics;


#line 1 "C:\Projects\Paradox\sources\shaders\DefaultForwardEffect.pdxfx"
using SiliconStudio.Paradox.Effects.Data;

#line 2
using SiliconStudio.Paradox.Effects.Modules;

#line 3
using SiliconStudio.Paradox.Engine;

#line 5
namespace DefaultForward
{

    #line 7
    public partial class ParadoxLightingTypeShader  : IShaderMixinBuilder
    {
        public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
        {

            #line 11
            if (context.GetParam(MaterialParameters.LightingType) == MaterialLightingType.DiffusePixel)
            {

                #line 13
                context.Mixin(mixin, "ShadingDiffusePerPixel");
            }

            #line 15
            else 
#line 15
            if (context.GetParam(MaterialParameters.LightingType) == MaterialLightingType.DiffuseVertex)
            {

                #line 17
                context.Mixin(mixin, "ShadingDiffusePerVertex");
            }

            #line 19
            else 
#line 19
            if (context.GetParam(MaterialParameters.LightingType) == MaterialLightingType.DiffuseSpecularPixel)
            {

                #line 21
                context.Mixin(mixin, "ShadingDiffuseSpecularPerPixel");
            }

            #line 23
            else 
#line 23
            if (context.GetParam(MaterialParameters.LightingType) == MaterialLightingType.DiffuseVertexSpecularPixel)
            {

                #line 25
                context.Mixin(mixin, "ShadingDiffusePerVertexSpecularPerPixel");
            }
        }

        [ModuleInitializer]
        internal static void __Initialize__()

        {
            ShaderMixinManager.Register("ParadoxLightingTypeShader", new ParadoxLightingTypeShader());
        }
    }

    #line 29
    public partial class ParadoxPointLightsShader  : IShaderMixinBuilder
    {
        public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
        {

            #line 34
            mixin.Mixin.AddMacro("LIGHTING_MAX_LIGHT_COUNT", context.GetParam(LightingKeys.MaxPointLights));

            #line 38
            context.Mixin(mixin, "ParadoxLightingTypeShader");

            #line 39
            context.Mixin(mixin, "PointShading");

            #line 40
            context.Mixin(mixin, "ShadingEyeNormalVS");
        }

        [ModuleInitializer]
        internal static void __Initialize__()

        {
            ShaderMixinManager.Register("ParadoxPointLightsShader", new ParadoxPointLightsShader());
        }
    }

    #line 43
    public partial class ParadoxSpotLightsShader  : IShaderMixinBuilder
    {
        public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
        {

            #line 48
            mixin.Mixin.AddMacro("LIGHTING_MAX_LIGHT_COUNT", context.GetParam(LightingKeys.MaxSpotLights));

            #line 52
            context.Mixin(mixin, "ParadoxLightingTypeShader");

            #line 53
            context.Mixin(mixin, "SpotShading");

            #line 54
            context.Mixin(mixin, "ShadingEyeNormalVS");
        }

        [ModuleInitializer]
        internal static void __Initialize__()

        {
            ShaderMixinManager.Register("ParadoxSpotLightsShader", new ParadoxSpotLightsShader());
        }
    }

    #line 57
    public partial class ParadoxDirectionalLightsShader  : IShaderMixinBuilder
    {
        public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
        {

            #line 63
            mixin.Mixin.AddMacro("LIGHTING_MAX_LIGHT_COUNT", context.GetParam(LightingKeys.MaxDirectionalLights));

            #line 67
            context.Mixin(mixin, "ParadoxLightingTypeShader");

            #line 68
            context.Mixin(mixin, "DirectionalShading");

            #line 69
            context.Mixin(mixin, "ShadingEyeNormalVS");
        }

        [ModuleInitializer]
        internal static void __Initialize__()

        {
            ShaderMixinManager.Register("ParadoxDirectionalLightsShader", new ParadoxDirectionalLightsShader());
        }
    }

    #line 72
    public partial class ParadoxDirectionalShadowLightsShader  : IShaderMixinBuilder
    {
        public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
        {

            #line 79
            mixin.Mixin.AddMacro("LIGHTING_MAX_LIGHT_COUNT", context.GetParam(ShadowMapParameters.ShadowMapCount));

            #line 82
            context.Mixin(mixin, "ParadoxLightingTypeShader");

            #line 83
            context.Mixin(mixin, "ShadingPerPixelShadow");

            #line 84
            context.Mixin(mixin, "DirectionalShading");

            #line 85
            context.Mixin(mixin, "ShadingEyeNormalVS");

            #line 88
            context.Mixin(mixin, "ShadowMapCascadeBase");

            #line 90
            mixin.Mixin.AddMacro("SHADOWMAP_COUNT", context.GetParam(ShadowMapParameters.ShadowMapCount));

            #line 91
            mixin.Mixin.AddMacro("SHADOWMAP_CASCADE_COUNT", context.GetParam(ShadowMapParameters.ShadowMapCascadeCount));

            #line 92
            mixin.Mixin.AddMacro("SHADOWMAP_TOTAL_COUNT", context.GetParam(ShadowMapParameters.ShadowMapCount) * context.GetParam(ShadowMapParameters.ShadowMapCascadeCount));

            #line 95
            if (context.GetParam(ShadowMapParameters.FilterType) == ShadowMapFilterType.Nearest)

                #line 96
                context.Mixin(mixin, "ShadowMapFilterDefault");

            #line 97
            else 
#line 97
            if (context.GetParam(ShadowMapParameters.FilterType) == ShadowMapFilterType.PercentageCloserFiltering)

                #line 98
                context.Mixin(mixin, "ShadowMapFilterPcf");

            #line 99
            else 
#line 99
            if (context.GetParam(ShadowMapParameters.FilterType) == ShadowMapFilterType.Variance)

                #line 100
                context.Mixin(mixin, "ShadowMapFilterVsm");
        }

        [ModuleInitializer]
        internal static void __Initialize__()

        {
            ShaderMixinManager.Register("ParadoxDirectionalShadowLightsShader", new ParadoxDirectionalShadowLightsShader());
        }
    }

    #line 103
    public partial class ParadoxDiffuseForward  : IShaderMixinBuilder
    {
        public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
        {

            #line 109
            context.Mixin(mixin, "BRDFDiffuseBase");

            #line 110
            context.Mixin(mixin, "BRDFSpecularBase");

            #line 112
            if (context.GetParam(MaterialParameters.AlbedoDiffuse) != null)
            {

                #line 114
                context.Mixin(mixin, "AlbedoDiffuseBase");

                {

                    #line 115
                    var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                    #line 115
                    context.Mixin(__subMixin, context.GetParam(MaterialParameters.AlbedoDiffuse));
                    mixin.Mixin.AddComposition("albedoDiffuse", __subMixin.Mixin);
                }

                #line 117
                if (context.GetParam(LightingKeys.MaxDirectionalLights) > 0 || context.GetParam(LightingKeys.MaxSpotLights) > 0 || context.GetParam(LightingKeys.MaxPointLights) > 0 || (context.GetParam(LightingKeys.ReceiveShadows) && context.GetParam(ShadowMapParameters.ShadowMaps) != null && context.GetParam(ShadowMapParameters.ShadowMaps).Length > 0))
                {

                    #line 119
                    if (context.GetParam(LightingKeys.MaxDirectionalLights) > 0 || context.GetParam(LightingKeys.MaxSpotLights) > 0 || context.GetParam(LightingKeys.MaxPointLights) > 0)
                    {

                        #line 121
                        context.Mixin(mixin, "GroupShadingBase");

                        #line 123
                        if (context.GetParam(LightingKeys.MaxDirectionalLights) > 0)

                            {

                                #line 124
                                var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                                #line 124
                                context.Mixin(__subMixin, "ParadoxDirectionalLightsShader");
                                mixin.Mixin.AddCompositionToArray("ShadingGroups", __subMixin.Mixin);
                            }

                        #line 125
                        if (context.GetParam(LightingKeys.MaxSpotLights) > 0)

                            {

                                #line 126
                                var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                                #line 126
                                context.Mixin(__subMixin, "ParadoxSpotLightsShader");
                                mixin.Mixin.AddCompositionToArray("ShadingGroups", __subMixin.Mixin);
                            }

                        #line 127
                        if (context.GetParam(LightingKeys.MaxPointLights) > 0)

                            {

                                #line 128
                                var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                                #line 128
                                context.Mixin(__subMixin, "ParadoxPointLightsShader");
                                mixin.Mixin.AddCompositionToArray("ShadingGroups", __subMixin.Mixin);
                            }
                    }

                    #line 130
                    if (context.GetParam(LightingKeys.ReceiveShadows) && context.GetParam(ShadowMapParameters.ShadowMaps) != null && context.GetParam(ShadowMapParameters.ShadowMaps).Length > 0)
                    {

                        #line 132
                        context.Mixin(mixin, "ShadowMapReceiver");

                        #line 133
                        foreach(var ____1 in context.GetParam(ShadowMapParameters.ShadowMaps))

                        {

                            #line 133
                            context.PushParameters(____1);

                            {

                                #line 135
                                var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                                #line 135
                                context.Mixin(__subMixin, "ParadoxDirectionalShadowLightsShader");
                                mixin.Mixin.AddCompositionToArray("shadows", __subMixin.Mixin);
                            }

                            #line 133
                            context.PopParameters();
                        }
                    }

                    #line 139
                    if (context.GetParam(MaterialParameters.DiffuseModel) == MaterialDiffuseModel.None || context.GetParam(MaterialParameters.DiffuseModel) == MaterialDiffuseModel.Lambert)
                    {

                        {

                            #line 141
                            var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                            #line 141
                            context.Mixin(__subMixin, "ComputeBRDFDiffuseLambert");
                            mixin.Mixin.AddComposition("DiffuseLighting", __subMixin.Mixin);
                        }
                    }

                    #line 143
                    else 
#line 143
                    if (context.GetParam(MaterialParameters.DiffuseModel) == MaterialDiffuseModel.OrenNayar)
                    {

                        {

                            #line 145
                            var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                            #line 145
                            context.Mixin(__subMixin, "ComputeBRDFDiffuseOrenNayar");
                            mixin.Mixin.AddComposition("DiffuseLighting", __subMixin.Mixin);
                        }
                    }
                }

                #line 149
                else
                {

                    #line 150
                    context.Mixin(mixin, "AlbedoFlatShading");
                }
            }
        }

        [ModuleInitializer]
        internal static void __Initialize__()

        {
            ShaderMixinManager.Register("ParadoxDiffuseForward", new ParadoxDiffuseForward());
        }
    }

    #line 155
    public partial class ParadoxSpecularLighting  : IShaderMixinBuilder
    {
        public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
        {

            #line 159
            if (context.GetParam(MaterialParameters.SpecularModel) == MaterialSpecularModel.None || context.GetParam(MaterialParameters.SpecularModel) == MaterialSpecularModel.Phong)
            {

                #line 161
                context.Mixin(mixin, "ComputeBRDFColorSpecularPhong");
            }

            #line 163
            else 
#line 163
            if (context.GetParam(MaterialParameters.SpecularModel) == MaterialSpecularModel.BlinnPhong)
            {

                #line 165
                context.Mixin(mixin, "ComputeBRDFColorSpecularBlinnPhong");
            }

            #line 173
            if (context.GetParam(MaterialParameters.SpecularPowerMap) != null)
            {

                #line 175
                context.Mixin(mixin, "SpecularPower");

                {

                    #line 176
                    var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                    #line 176
                    context.Mixin(__subMixin, context.GetParam(MaterialParameters.SpecularPowerMap));
                    mixin.Mixin.AddComposition("SpecularPowerMap", __subMixin.Mixin);
                }
            }

            #line 179
            if (context.GetParam(MaterialParameters.SpecularIntensityMap) != null)
            {

                {

                    #line 181
                    var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                    #line 181
                    context.Mixin(__subMixin, context.GetParam(MaterialParameters.SpecularIntensityMap));
                    mixin.Mixin.AddComposition("SpecularIntensityMap", __subMixin.Mixin);
                }
            }
        }

        [ModuleInitializer]
        internal static void __Initialize__()

        {
            ShaderMixinManager.Register("ParadoxSpecularLighting", new ParadoxSpecularLighting());
        }
    }

    #line 185
    public partial class ParadoxSpecularForward  : IShaderMixinBuilder
    {
        public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
        {

            #line 190
            context.Mixin(mixin, "BRDFDiffuseBase");

            #line 191
            context.Mixin(mixin, "BRDFSpecularBase");

            #line 193
            if (context.GetParam(MaterialParameters.AlbedoSpecular) != null)
            {

                #line 195
                context.Mixin(mixin, "AlbedoSpecularBase");

                {

                    #line 196
                    var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                    #line 196
                    context.Mixin(__subMixin, context.GetParam(MaterialParameters.AlbedoSpecular));
                    mixin.Mixin.AddComposition("albedoSpecular", __subMixin.Mixin);
                }

                {

                    #line 197
                    var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                    #line 197
                    context.Mixin(__subMixin, "ParadoxSpecularLighting");
                    mixin.Mixin.AddComposition("SpecularLighting", __subMixin.Mixin);
                }
            }
        }

        [ModuleInitializer]
        internal static void __Initialize__()

        {
            ShaderMixinManager.Register("ParadoxSpecularForward", new ParadoxSpecularForward());
        }
    }

    #line 201
    public partial class ParadoxDefaultForwardShader  : IShaderMixinBuilder
    {
        public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
        {

            #line 205
            context.Mixin(mixin, "ParadoxBaseShader");

            #line 207
            context.Mixin(mixin, "ParadoxSkinning");

            #line 209
            context.Mixin(mixin, "ParadoxShadowCast");

            #line 211
            context.Mixin(mixin, "ParadoxDiffuseForward");

            #line 212
            context.Mixin(mixin, "ParadoxSpecularForward");

            #line 214
            if (context.GetParam(MaterialParameters.AmbientMap) != null)
            {

                #line 216
                context.Mixin(mixin, "AmbientMapShading");

                {

                    #line 217
                    var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                    #line 217
                    context.Mixin(__subMixin, context.GetParam(MaterialParameters.AmbientMap));
                    mixin.Mixin.AddComposition("AmbientMap", __subMixin.Mixin);
                }
            }

            #line 220
            if (context.GetParam(MaterialParameters.UseTransparentMask))
            {

                #line 222
                context.Mixin(mixin, "TransparentShading");

                #line 223
                context.Mixin(mixin, "DiscardTransparentThreshold", context.GetParam(MaterialParameters.AlphaDiscardThreshold));
            }

            #line 225
            else 
#line 225
            if (context.GetParam(MaterialParameters.UseTransparent))
            {

                #line 227
                context.Mixin(mixin, "TransparentShading");

                #line 228
                context.Mixin(mixin, "DiscardTransparent");
            }
        }

        [ModuleInitializer]
        internal static void __Initialize__()

        {
            ShaderMixinManager.Register("ParadoxDefaultForwardShader", new ParadoxDefaultForwardShader());
        }
    }
}
