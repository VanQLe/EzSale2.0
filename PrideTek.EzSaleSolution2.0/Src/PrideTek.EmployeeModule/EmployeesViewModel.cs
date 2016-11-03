using PrideTek.EmployeeModule.Interfaces;
using PrideTek.EzSale.Infrastructure;
using PrideTek.Shell.Core.Navigation;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.EmployeeModule
{
    public class EmployeesViewModel:IEmployeesViewModel
    {
        public string ViewHeader { get; set; }
        private INavigationManager _navManager { get; set; }
        private NavigationItem _navItem { get; set; }

        public DelegateCommand<string> NavCommand { get; set; }

        public EmployeesViewModel(INavigationManager navManager)
        {
            ViewHeader = "Employees";
            _navManager = navManager;
            _navItem = new NavigationItem();
            NavCommand = new DelegateCommand<string>(NavTo);
        }

        private void NavTo(string navPath)
         {
            _navItem.ScreenType = navPath;
            _navItem.ScreenRegion = RegionNames.ContentRegion;

            _navManager.NavigateTo(_navItem);
        }
    }
}
