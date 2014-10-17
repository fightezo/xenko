﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;
using System.Collections;
using System.Collections.Generic;

namespace SiliconStudio.Shaders.Ast
{
    /// <summary>
    /// An assigment expression
    /// </summary>
    public class AssignmentExpression : Expression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssignmentExpression"/> class.
        /// </summary>
        public AssignmentExpression()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignmentExpression"/> class.
        /// </summary>
        /// <param name="operator">The @operator.</param>
        /// <param name="target">The target.</param>
        /// <param name="value">The value.</param>
        public AssignmentExpression(AssignmentOperator @operator, Expression target, Expression value)
        {
            Operator = @operator;
            Target = target;
            Value = value;
        }

        #region Public Properties

        /// <summary>
        ///   Gets or sets the operator.
        /// </summary>
        /// <value>
        ///   The operator.
        /// </value>
        public AssignmentOperator Operator { get; set; }

        /// <summary>
        ///   Gets or sets the target receving the assigment.
        /// </summary>
        /// <value>
        ///   The target.
        /// </value>
        public Expression Target { get; set; }

        /// <summary>
        ///   Gets or sets the value of the assigment..
        /// </summary>
        /// <value>
        ///   The value.
        /// </value>
        public Expression Value { get; set; }

        #endregion

        #region Public Methods
        
        /// <inheritdoc />
        public override IEnumerable<Node> Childrens()
        {
            ChildrenList.Clear();
            ChildrenList.Add(Target);
            ChildrenList.Add(Value);
            return ChildrenList;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Target, Operator.ConvertToString(), Value);
        }

        #endregion
    }
}