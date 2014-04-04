#region Copyleft and Copyright

// NAnt-Gui - Gui frontend to the NAnt .NET build tool
// Copyright (C) 2004-2007 Colin Svingen
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//
// Colin Svingen (swoogan@gmail.com)

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using NAntGui.Framework;

namespace NAntGui.Gui
{
    /// <summary>
    /// Summary description for PropertyShelf
    /// </summary>
    internal class PropertyShelf : ICustomTypeDescriptor
    {
        #region BuildPropertyDescriptor class definition

        private class BuildPropertyDescriptor : PropertyDescriptor
        {
            private readonly IBuildProperty _item;

            internal BuildPropertyDescriptor(IBuildProperty item, Attribute[] attrs) :
                base(item.Name, attrs)
            {
                _item = item;
            }

            public override Type ComponentType
            {
                get { return _item.GetType(); }
            }

            public override bool IsReadOnly
            {
                get { return _item.ReadOnly; }
            }

            public override Type PropertyType
            {
                get { return _item.Type; }
            }

            public override bool CanResetValue(object component)
            {
                return _item.DefaultExpandedValue == null
                           ? false
                           : _item.ExpandedValue != _item.DefaultExpandedValue;
            }

            public override object GetValue(object component)
            {
                return _item.ExpandedValue;
            }

            public override void ResetValue(object component)
            {
                SetValue(component, _item.DefaultExpandedValue);
            }

            public override void SetValue(object component, object value)
            {
                _item.ExpandedValue = value.ToString();
            }

            public override bool ShouldSerializeValue(object component)
            {
                return _item.DefaultExpandedValue == null
                           ? false
                           : _item.ExpandedValue != _item.DefaultExpandedValue;
            }
        }

        #endregion

        private readonly List<IBuildProperty> _properties;

        internal PropertyShelf(List<IBuildProperty> properties)
        {
            Assert.NotNull(properties, "properties");
            _properties = properties;
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            // Rather than passing this function on to the default TypeDescriptor,
            // which would return the actual properties of this object, I construct
            // a list here that contains property descriptors for the elements of the
            // _properties List.

            List<BuildPropertyDescriptor> props = new List<BuildPropertyDescriptor>();

            foreach (IBuildProperty property in _properties)
            {
                List<Attribute> attrs = new List<Attribute>();

                if (property.Category != null)
                    attrs.Add(new CategoryAttribute(property.Category));

                BuildPropertyDescriptor pd = new BuildPropertyDescriptor(property, attrs.ToArray());
                props.Add(pd);
            }

            return new PropertyDescriptorCollection(props.ToArray());
        }

        #region Useless ICustomTypeDescriptor methods

        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        string ICustomTypeDescriptor.GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        string ICustomTypeDescriptor.GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        {
            return null;
        }

        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor) this).GetProperties(new Attribute[0]);
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        #endregion
    }
}