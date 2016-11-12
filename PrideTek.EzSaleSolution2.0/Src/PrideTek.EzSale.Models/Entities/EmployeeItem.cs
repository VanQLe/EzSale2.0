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
