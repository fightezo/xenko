﻿/*************************************************************************************

   Extended WPF Toolkit

   Copyright (C) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
   Copyright (C) 2007-2013 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at http://xceed.com/wpf_toolkit

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ***********************************************************************************/

using System.Collections.Generic;

namespace SiliconStudio.Presentation.Controls.PropertyGrid.Attributes
{
    public interface IItemsSource
    {
        ItemCollection GetValues();
    }

    public class Item
    {
        public string DisplayName { get; set; }
        public object Value { get; set; }
    }

    public class ItemCollection : List<Item>
    {
        public void Add(object value)
        {
            var item = new Item { DisplayName = value.ToString(), Value = value };
            base.Add(item);
        }

        public void Add(object value, string displayName)
        {
            var newItem = new Item { DisplayName = displayName, Value = value };
            base.Add(newItem);
        }
    }
}
