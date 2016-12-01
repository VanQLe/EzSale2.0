using PrideTek.Shell.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.EzSale.Models.Entities
{
    public class ModelWrapper<T> : NotificationObject
    {

        private Dictionary<string, object> _originalValues;//this dictionary will hold all the orignal values for all the properties for the model.

        //The Model property that the wrapper created from
        public T Model { get; private set; }

      
        public ModelWrapper(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            Model = model;//now Model reference the friend that was sent in.
            _originalValues = new Dictionary<string, object>(); //initialize the _originalvalue dictionary
        }

        protected bool GetIsChanged(string propertyName)
        {
            return _originalValues.ContainsKey(propertyName);//if the _originalValue dictionary contain the propertyName (key), that mean the value has been changed, since there is an originalValue within the _originalValue dictionary
        }

        /// <summary>
        /// A generic method that only require the caller type to get the property value
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);
            return (TValue)propertyInfo.GetValue(Model);
        }

        /// <summary>
        /// Get the originalValue of the property by passing in the propertyName
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected TValue GetOriginalValue<TValue>(string propertyName)
        {
            //if the _originalValue dictionary has the propertyName return the value, else call the GetValue() method to get the currentvalue for the property.
            return _originalValues.ContainsKey(propertyName)
                ?(TValue) _originalValues[propertyName]//return original value
                : GetValue<TValue>(propertyName);//else return the value currently value of the property.
        }

        /// <summary>
        /// Set the value if the property value does not equal the new value;
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        protected void SetValue<TValue>(TValue newValue, [CallerMemberName] string propertyName = "")
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);//Get the type and property field
            var currentValue = propertyInfo.GetValue(Model);//Get the value of the current value from the Modeltype-property field.  If newValue does not equal currentValue, the currentValue will be the originalValue for this property.
            if (!Equals(currentValue, newValue))
            {
                UpdateOriginalValue(currentValue,newValue, propertyName);//update the orignal value since a new value will be set
                propertyInfo.SetValue(Model, newValue);
                NotifyPropertyChanged(propertyName);//Noitfy that the property has been changed
                NotifyPropertyChanged(propertyName + "IsChanged");//notify that the IsChanged for that property has been changed.
            }
        }

        private void UpdateOriginalValue(object currentValue,object newValue, string propertyName)
        {
            if (!_originalValues.ContainsKey(propertyName))
            {
                //if the _originalValue dictionary does not contain the property, add it to the dictionary.
                _originalValues.Add(propertyName, currentValue);
            }
            else
            {
                //Remove the original value from the dictionary if the new value is equal.
                if(Equals(_originalValues[propertyName], newValue))
                {
                    _originalValues.Remove(propertyName);
                }
 
            }
        }
    }
}
