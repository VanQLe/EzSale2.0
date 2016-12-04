using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PrideTek.EzSale.Infrastructure.Behaviors
{
    public class ChangeBehavior
    {
        //Dictionary
        private static readonly Dictionary<Type, DependencyProperty> _defaultProperties;

        public static readonly DependencyProperty OriginalValueProperty;
        public static readonly DependencyProperty IsChangedProperty;
        public static readonly DependencyProperty PropertyNameProperty;
        public static readonly DependencyProperty IsActiveProperty;


        static ChangeBehavior()
        {
            IsActiveProperty = DependencyProperty.RegisterAttached("IsActive", typeof(bool), typeof(ChangeBehavior), new PropertyMetadata(false, OnIsActivePropertyChange));
            OriginalValueProperty = DependencyProperty.RegisterAttached("OriginalValue", typeof(object), typeof(ChangeBehavior), new PropertyMetadata(null));
            IsChangedProperty = DependencyProperty.RegisterAttached("IsChanged", typeof(bool), typeof(ChangeBehavior), new PropertyMetadata(null));
            PropertyNameProperty = DependencyProperty.RegisterAttached("PropertyName", typeof(string), typeof(ChangeBehavior), new PropertyMetadata(null));
            _defaultProperties = new Dictionary<Type, DependencyProperty>
            {
                //{typeof(TextBox), TextBox.TextProperty }
                //or you can write the above code for more readibilty
                [typeof(TextBox)] = TextBox.TextProperty //So TextBox type(Key), and Textbox.TextProperty(Value).  Is one entry for this dictionary
            };
        }

        
        #region Attach Property OriginalValue
        public static object GetOriginalValue(DependencyObject obj)
        {
            return (object)obj.GetValue(OriginalValueProperty);
        }

        public static void SetOriginalValue(DependencyObject obj, object value)
        {
            obj.SetValue(OriginalValueProperty, value);
        }
        #endregion

        #region Attach Property IsChanged
        public static bool GetIsChanged(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsChangedProperty);
        }

        public static void SetIsChanged(DependencyObject obj, bool value)
        {
            obj.SetValue(IsChangedProperty, value);
        }
        #endregion

        #region Property PropertyName
        public static string GetPropertyName(DependencyObject obj)
        {
            if ((string)obj.GetValue(PropertyNameProperty) == null || (string)obj.GetValue(PropertyNameProperty) == "")
            {
                return "";
            }
            else
            {
                return (string)obj.GetValue(PropertyNameProperty);
            }

        }

        public static void SetPropertyName(DependencyObject obj, string value)
        {
            obj.SetValue(PropertyNameProperty, value);
        }
        #endregion

        #region Attach Property IsActive


        public static bool GetIsActive(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsActiveProperty);
        }

        public static void SetIsActive(DependencyObject obj, bool value)
        {
            obj.SetValue(IsActiveProperty, value);
        }

        private static void OnIsActivePropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //Dependency Object d: d is the object that the attach property was set to.  So, d is the object that the attach property IsActive is set to.  If we set the attach property on a textbox, d is the textbox instance.

            //1: Get the binding of the control text property
            //2: We created a dictionary that has a Key TextBox type and Text.Property dependency property
            //3:Get the Dependency property for that Depedenecny Object that the attach property was set to.
            //4: Check if the attach property has set to true; (IsActive)
            //5: Get the binding path of the dependency property
            //6: Set a databinding for the Originalvalue and IsChanged if IsActive is set to true
            //7: Clear IsChanged and OriginalValue binding if IsActive is false

            //if our dictionary has a type, run the if statement.  Ex.  If the _default type dictionary has the textbox type key, and "d"(dependency object) is that type, run the if statement.
            if (_defaultProperties.ContainsKey(d.GetType()))
            {
                var defaultProperty = _defaultProperties[d.GetType()];
                if((bool)e.NewValue)//check if IsActive is true
                {
                    var dpBinding = BindingOperations.GetBinding(d, defaultProperty);//This holds the binding for the depenedency property

                    if(dpBinding !=null)//check if there is a binding
                    {
                        string bindingPath = dpBinding.Path.Path;//return the string of the binding name

                        //Now we need to set the binding for dp OriginalValue and IsChanged
                        BindingOperations.SetBinding(d, IsChangedProperty, new Binding(bindingPath + "IsChanged"));
                        BindingOperations.SetBinding(d, OriginalValueProperty, new Binding(bindingPath + "OriginalValue"));
                    }
                    else
                    {
                        BindingOperations.ClearBinding(d,IsChangedProperty);
                        BindingOperations.ClearBinding(d, OriginalValueProperty);
                    }
                }
            }
        }


        #endregion

    }
}
