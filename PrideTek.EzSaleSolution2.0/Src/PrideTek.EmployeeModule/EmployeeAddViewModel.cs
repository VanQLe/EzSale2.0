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
using PrideTek.EzSale.Infrastructure.Events;

namespace PrideTek.EmployeeModule
{
    public class EmployeeAddViewModel : BaseViewModel, IEmployeeAddViewModel, INavigationAware, IRegionMemberLifetime
    {
        public string ViewTitle { get; set; }
        public string TabTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeeWrapper SelectedItem { get; set; }
        public DelegateCommand<string> SaveCommand { get; private set; }
        public DelegateCommand<string> CancelCommand { get; private set; }
        private INavigationManager _navManager { get; set; }
        private IGenericClientService _clientService { get; set; }
        private IEventAggregator _eventAggregator { get; set; }

        private bool _isNewEmployee { get; set; }
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
   
        public EmployeeAddViewModel(INavigationManager navManager, IGenericClientService clientService, IEventAggregator eventAggregator)
        {
            _clientService = clientService;
            _navManager = navManager;
            _eventAggregator = eventAggregator;
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
            string statusMsg = "";

            _clientService.Update<Employee>(SelectedItem.Model);
            if (_isNewEmployee)
            {
                statusMsg = String.Format("{0} {1} was added as a new employee", SelectedItem.FirstName, SelectedItem.LastName);
            }
            else
                statusMsg = String.Format("Updated Employee {0} {1} info", SelectedItem.FirstName, SelectedItem.LastName);

            _eventAggregator.GetEvent<StatusBarEvent>().Publish(statusMsg + DateTime.Now);
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
            if (navigationContext.NavigationService.Region.Context != null && navigationContext.NavigationService.Region.Context is EmployeeWrapper)
            {
                CloneEmployee((EmployeeWrapper)navigationContext.NavigationService.Region.Context);
                ViewTitle = "Edit Employee View";
                navigationContext.NavigationService.Region.Context = null;
                _isNewEmployee = false;
            }
            else
            {
                SelectedItem = new EmployeeWrapper(new Employee());
                ViewTitle = "Add new employee";
                TabTitle = "Info";
                SelectedItem.FirstName = null;
                SelectedItem.LastName = null;
                _isNewEmployee = true;
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
         
        }

        private void CloneEmployee(EmployeeWrapper employee)
        {
            SelectedItem = new EmployeeWrapper(_clientService.GetById<Employee>((long)employee.EmployeeId));//get the employee and wrapper it.
        }
    }

}
