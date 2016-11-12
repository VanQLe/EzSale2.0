using PrideTek.EzSale.StatusBarModule.Interfaces;
using PrideTek.Shell.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.EzSale.StatusBarModule
{
    public class StatusBarViewModel: BaseViewModel,IStatusBarViewModel
    {
        private string _statusBarText;

        public string StatusBarText
        {
            get
            {
                return _statusBarText;
            }

            set
            {
                SetField(ref _statusBarText, value);
            }
        }

        public StatusBarViewModel()
        {
            StatusBarText = "Hello";
        }
    }
}
