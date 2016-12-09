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
using PrideTek.Shell.Common.Views.Services.MessageDialog;

namespace PrideTek.EmployeeModule
{
    public class EmployeeAddViewModel : BaseViewModel, IEmployeeAddViewModel, INavigationAware, IRegionMemberLifetime
    {
        public string ViewTitle { get; set; }
        public string TabTitle { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        private EmployeeWrapper _selectedItem;
        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand<string> CancelCommand { get; private set; }
        public DelegateCommand ResetCommand { get; set; }
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
            SaveCommand = new DelegateCommand(SaveEntity, ModelIsChanged);
            CancelCommand = new DelegateCommand<string>(CancelMethod);
            ResetCommand = new DelegateCommand(ResetEntity, ModelIsChanged);
        }

        private void CancelMethod(string navPath)
        {
            if (SelectedItem.IsChanged)
            {
                var messageBox = new MessageDialogService();
                var result = messageBox.ShowYesNoDialog("Close Tab?", "You will lose your changes if you close this tab.  Close it?", MessageDialogResult.No);

                if(result == MessageDialogResult.No)
                {
                    return;//if user click no, remind in that view.  
                }
            }
      
            NavTo(navPath);//Will navigate to a different view if the user click yes for the Yes or no MessageBox.
        }

        public EmployeeWrapper SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            private set
            {
                SetField(ref _selectedItem, value);
            }

        }
        public void ResetEntity()
        {
            SelectedItem.RejectChanges();
        }
        private bool ModelIsChanged()
        {
            return SelectedItem.IsChanged;
        }

        private async void SaveEntity()
        {
            
            try
            {
              await SaveAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to update Employee: Internal Error");
            }
        }

        private async Task SaveAsync()
        {
            var statusBarMsg = "";

            try
            {
                await Task.Run(() =>
                {
                    if ((bool)SelectedItem.IsNew)
                    {
                        statusBarMsg = String.Format("{0} {1} was added as a new employee successfully", SelectedItem.FirstName, SelectedItem.LastName);
                    }
                    else
                    {
                        statusBarMsg = String.Format("Updated Employee {0} {1} information successfully", SelectedItem.FirstName, SelectedItem.LastName);
                    }
                    _clientService.Update<Employee>(SelectedItem.Model);
                    SelectedItem.AcceptChanges();
                    _eventAggregator.GetEvent<StatusBarEvent>().Publish(statusBarMsg + DateTime.Now);
                });
            }
            catch
            {
                if ((bool)SelectedItem.IsNew)
                {
                    statusBarMsg = String.Format("Failed to add new employee {0} {1}", SelectedItem.FirstName, SelectedItem.LastName);
                }
                else
                {
                    statusBarMsg = String.Format("Failed to update {0} {1} info", SelectedItem.FirstName, SelectedItem.LastName);
                }

                _eventAggregator.GetEvent<StatusBarEvent>().Publish(statusBarMsg + DateTime.Now);
                SelectedItem.RejectChanges();
            }
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
                SetSelectedItem((EmployeeWrapper)navigationContext.NavigationService.Region.Context);
                ViewTitle = "Edit Employee View";
                navigationContext.NavigationService.Region.Context = null;
                _isNewEmployee = false;
            }
            else
            {
                SetSelectedItem(new EmployeeWrapper(new Employee()));
                ViewTitle = "Add new employee";
                TabTitle = "Info";
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

        private void SetSelectedItem(EmployeeWrapper employeeWrapper)
        {
            SelectedItem = employeeWrapper; 
            SelectedItem.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(SelectedItem.IsChanged))
                {
                    SaveCommand.RaiseCanExecuteChanged();
                    ResetCommand.RaiseCanExecuteChanged();
                    _eventAggregator.GetEvent<ModelIsChangedEvent>().Publish(SelectedItem.IsChanged);//Notify the mainwindow that there are changes, to prompt user not to close window.
                }
            };
        }
    }

}
