using Microsoft.Practices.Unity;
using PrideTek.EmployeeModule.Interfaces;
using PrideTek.EzSale.Infrastructure;
using PrideTek.Shell.Core.Navigation;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrideTek.EzSale.Models.Entities;
using System.Windows;
using PrideTek.Shell.Common.ViewModels;
using PrideTek.EzSale.ClientService;

namespace PrideTek.EmployeeModule
{
    public class EmployeeAddViewModel : BaseViewModel, IEmployeeAddViewModel, INavigationAware, IRegionMemberLifetime
    {
        public string ViewTitle { get; set; }
        public string TabTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee SelectedItem { get; set; }

            
        public DelegateCommand<string> SaveCommand { get; private set; }
        public DelegateCommand<string> CancelCommand { get; private set; }

        private INavigationManager _navManager { get; set; }
        private IGenericClientService _clientService { get; set; }
        /// <summary>
        /// Regionmanager will re-create this class everytime it's called.
        /// </summary>
        public bool KeepAlive
        {
            get
            {
                return false;
            }
        }

        private NavigationItem _navItem;
   
        public EmployeeAddViewModel(INavigationManager navManager, IGenericClientService clientService)
        {
            _clientService = clientService;
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
            _clientService.Update<Employee>(SelectedItem);

            NavTo(navPath);
        }

        private void NavTo(string navPath)
        {
            _navItem.ScreenType = navPath;
            _navItem.ScreenRegion = RegionNames.ContentRegion;

            _navManager.NavigateTo(_navItem);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {


            if (navigationContext.NavigationService.Region.Context != null && navigationContext.NavigationService.Region.Context is Employee)
            {
                CloneEmployee((Employee)navigationContext.NavigationService.Region.Context);
     
                ViewTitle = "Edit Employee View";
                navigationContext.NavigationService.Region.Context = null;
            }
            else
            {
                SelectedItem = new Employee();
                ViewTitle = "Add new employee";
                TabTitle = "Info";
                SelectedItem.FirstName = "First Name";
                SelectedItem.LastName = "Last Name";
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
         
        }

        private void CloneEmployee(Employee employee)
        {
            SelectedItem = _clientService.GetById<Employee>((long)employee.Id);
        }
    }

}
