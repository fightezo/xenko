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


#line 1 "C:\DEV\paradox\sources\engine\SiliconStudio.Paradox.Graphics.Tests\Compiler\ToGlslEffect.pdxfx"
namespace Test
{

    #line 3
    public partial class ToGlslEffect  : IShaderMixinBuilder
    {
        public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
        {

            #line 5
            context.Mixin(mixin, "ToGlslShader");
        }

        [ModuleInitializer]
        internal static void __Initialize__()

        {
            ShaderMixinManager.Register("ToGlslEffect", new ToGlslEffect());
        }
    }
}
