using Microsoft.Practices.Unity;
using PrideTek.EmployeeModule.Interfaces;
using PrideTek.EzSale.Infrastructure;
using PrideTek.Shell.Core.Navigation;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.EmployeeModule
{
    public class EmployeeAddViewModel:IEmployeeAddViewModel
    {
        public string ViewTitle { get; set; }
        public string TabTitle { get; set; }
        public DelegateCommand<string> SaveCommand { get; private set; }
        public DelegateCommand<string> CancelCommand { get; private set; }
      
        private INavigationManager _navManager { get; set; }
        private NavigationItem _navItem;

        public EmployeeAddViewModel(INavigationManager navManager)
        {
            ViewTitle = "Add new employee";
            TabTitle = "Info";
            _navManager = navManager;

            _navItem = new NavigationItem();
            SaveCommand = new DelegateCommand<string>(SaveMethod);
            CancelCommand = new DelegateCommand<string>(CancelMethod);
        }

        private void CancelMethod(string navPath)
        {
            NavTo(navPath);
        }

        private void SaveMethod(string navPath)
        {
            //ToDo Save data
            NavTo(navPath);
        }

        private void NavTo(string navPath)
        {
            _navItem.ScreenType = navPath;
            _navItem.ScreenRegion = RegionNames.ContentRegion;

            _navManager.NavigateTo(_navItem);
        }
    }

}
