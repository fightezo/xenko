﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;

using SiliconStudio.Core;

namespace SiliconStudio.Paradox.Effects
{
    public partial class MaterialParameters
    {
        /// <summary>
        /// Parameter key for the shading model.
        /// </summary>
        public static ParameterKey<MaterialShadingModel> ShadingModel = ParameterKeys.New<MaterialShadingModel>(MaterialShadingModel.Flat, "MaterialParameters.ShadingModel");

        /// <summary>
        /// Parameter key for the diffuse model.
        /// </summary>
        public static ParameterKey<MaterialDiffuseModel> DiffuseModel = ParameterKeys.New<MaterialDiffuseModel>(MaterialDiffuseModel.None, "MaterialParameters.DiffuseModel");

        /// <summary>
        /// Parameter key for the specular model.
        /// </summary>
        public static ParameterKey<MaterialSpecularModel> SpecularModel = ParameterKeys.New<MaterialSpecularModel>(MaterialSpecularModel.None, "MaterialParameters.SpecularModel");

        /// <summary>
        /// Parameter key for the lighting type.
        /// </summary>
        public static ParameterKey<MaterialLightingType> LightingType = ParameterKeys.New<MaterialLightingType>(MaterialLightingType.DiffuseSpecularPixel, "MaterialParameters.LightingType");
    }

    /// <summary>
    /// Shading interpolation model.
    /// </summary>
    [DataContract("MaterialShadingModel")]
    public enum MaterialShadingModel
    {
        Flat,
        Gouraud,
        Phong
    }

    /// <summary>
    /// Diffuse component model.
    /// </summary>
    [DataContract("MaterialDiffuseModel")]
    public enum MaterialDiffuseModel
    {
        None,
        Lambert,
        OrenNayar
    }

    /// <summary>
    /// Specular component model.
    /// </summary>
    [DataContract("MaterialSpecularModel")]
    public enum MaterialSpecularModel
    {
        None,
        Phong,
        BlinnPhong,
        CookTorrance
    }

    [Flags]
    [DataContract("MaterialLightingType")]
    public enum MaterialLightingType
    {
        DiffuseVertex = 1,
        DiffusePixel = 2,
        SpecularPixel = 4,

        DiffuseVertexSpecularPixel = DiffuseVertex | SpecularPixel,
        DiffuseSpecularPixel = DiffusePixel | SpecularPixel,
    }
}
