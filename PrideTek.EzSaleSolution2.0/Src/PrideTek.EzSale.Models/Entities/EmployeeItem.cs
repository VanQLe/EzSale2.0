using PrideTek.Shell.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.EzSale.Models.Entities
{
    public class EmployeeItem: NotificationObject
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                SetField(ref _isSelected, value);
            }
        }
        //private string _fullName;
        public string FullName
        {
            get
            {
                return this.Employee.FirstName + " " + this.Employee.LastName;
            }
        }

        public bool? IsDeleted
        {
            get
            {
               return Employee.IsDeleted;
            }
        }

        public Employee Employee
        {
            get
            {
                return _employee;
            }

            set
            {
                SetField(ref _employee, value);
            }
        }

        private Employee _employee;

    }
}
