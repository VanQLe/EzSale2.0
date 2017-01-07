using PrideTek.Shell.Common.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.Shell.Core.Errors
{
    public class NotifyDataErrorInfoBase : NotificationObject, INotifyDataErrorInfo
    {
        protected Dictionary<string, List<string>> Errors;//list of errors

        protected NotifyDataErrorInfoBase()
        {
            Errors = new Dictionary<string, List<string>>();
        }

        public bool HasErrors => Errors.Any();


        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;//Notify the UI that the errors has changed and refresh the UI relating to errors.

        public IEnumerable GetErrors(string propertyName)
        {
            return propertyName != null && Errors.ContainsKey(propertyName)
                    ? Errors[propertyName]
                    : Enumerable.Empty<string>(); //if propertyName is not null and Errors dictionary contain the propertyName key,  return the value of the propertyName key in the dictionary.  Else return an empty string collection (enumerable);
        }

        protected virtual void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));// if the ErrorsChanged is not null, invoke it and pass the object and dataerrorchangeeventarges with the propertyName
        }

        protected void ClearErrors()
        {
            foreach (var propertName in Errors.Keys.ToList())
            {
                Errors.Remove(propertName);
                OnErrorsChanged(propertName);
            }

        }
    }
}
