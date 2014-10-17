// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;
using System.Collections;
using System.Collections.Generic;

namespace SiliconStudio.Shaders.Ast.Hlsl
{
    /// <summary>
    /// A set of state values.
    /// </summary>
    public class StateInitializer : Expression
    {
        #region Constructors and Destructors

        /// <summary>
        ///   Initializes a new instance of the <see cref = "StateInitializer" /> class.
        /// </summary>
        public StateInitializer()
        {
            Items = new List<Expression>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets or sets the fields.
        /// </summary>
        /// <value>
        ///   The fields.
        /// </value>
        public List<Expression> Items { get; set; }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public override IEnumerable<Node> Childrens()
        {
            return Items;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return "{...}";
        }

        #endregion
    }
}