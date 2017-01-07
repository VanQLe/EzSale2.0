using PrideTek.Shell.Common.ViewModels;
using PrideTek.Shell.Core.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.EzSale.Models.Entities
{
    public class ModelWrapper<T> : NotifyDataErrorInfoBase, IRevertibleChangeTracking
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

            Validate();
        }

        /// <summary>
        /// Return true if the model has changes by looking at the _originalValue dictionary.  If there are any values in the dictionary, that mean the Model has been changed.
        /// </summary>


        protected bool GetIsChanged(string propertyName)
        {
            return _originalValues.ContainsKey(propertyName);//if the _originalValue dictionary contain the propertyName (key), that mean the value has been changed, since there is an originalValue within the _originalValue dictionary
        }

        public bool IsValid => !HasErrors;

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
                ? (TValue)_originalValues[propertyName]//return original value
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
                UpdateOriginalValue(currentValue, newValue, propertyName);//update the orignal value since a new value will be set
                propertyInfo.SetValue(Model, newValue);

                Validate();

                NotifyPropertyChanged(propertyName);//Fire notify changed property.
                NotifyPropertyChanged((propertyName) + "IsChanged");//Fire Notify changed for PropertyIsChanged changed
            }
        }

        private void Validate()//validate the whole object
        {
            ClearErrors();//remove errors

            var results = new List<ValidationResult>();
            var context = new ValidationContext(this);
            Validator.TryValidateObject(this, context, results, true);

            if (results.Any())//if true, there are errors
            {
                var propertyNames = results.SelectMany(r => r.MemberNames).Distinct().ToList();

                foreach (var propertyName in propertyNames)
                {
                    Errors[propertyName] = results
                        .Where(r => r.MemberNames.Contains(propertyName))
                        .Select(r => r.ErrorMessage)
                        .Distinct().ToList();

                    OnErrorsChanged(propertyName);
                }


                NotifyPropertyChanged(nameof(IsValid));
            }


            NotifyPropertyChanged(nameof(IsValid));
        }




        private void UpdateOriginalValue(object currentValue, object newValue, string propertyName)
        {
            if (!_originalValues.ContainsKey(propertyName))
            {
                //if the _originalValue dictionary does not contain the property, add it to the dictionary.
                _originalValues.Add(propertyName, currentValue);
                NotifyPropertyChanged("IsChanged");
            }
            else
            {
                //Remove the original value from the dictionary if the new value is equal.
                if (Equals(_originalValues[propertyName], newValue))
                {
                    _originalValues.Remove(propertyName);
                    NotifyPropertyChanged("IsChanged");
                }

            }
            //NotifyPropertyChanged("IsChanged");//Notify that the ModelIsChange has been changed.
        }

        //Once changes is accepted, this method will set the model to a new state.
        public void AcceptChanges()
        {
            _originalValues.Clear();//
            NotifyPropertyChanged("");//this will notify all properties to be fired.  This will refresh all the UI.
            NotifyPropertyChanged("IsChanged");
        }
        //This method will reset the model to the original state.
        public void RejectChanges()
        {
            //Property that was changed the original value will be stored in the _originalValues dictionary.  Use the _originalValue dictionary to set back the original value if model reject changes.
            foreach (var originalValueEntry in _originalValues)
            {
                var property = typeof(T).GetProperty(originalValueEntry.Key);//Get the property.
                property.SetValue(Model, originalValueEntry.Value);//Set value for the property for the model.
            }
            _originalValues.Clear();//clear the dictionary once all the value has set back to it's original value.
            NotifyPropertyChanged("");
            NotifyPropertyChanged("IsChanged");

            Validate();//check if the model is valid after reject changes.
        }

        /// <summary>
        /// Determine if this Model has been changed.  Return true if model has changed.
        /// </summary>
        public bool IsChanged => _originalValues.Count > 0;





    }
}
