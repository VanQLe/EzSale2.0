using PrideTek.CustomerModule.Interfaces;
using PrideTek.EzSale.ClientService;
using PrideTek.EzSale.Infrastructure;
using PrideTek.EzSale.Infrastructure.Events;
using PrideTek.EzSale.Models.Entities;
using PrideTek.Shell.Common.ViewModels;
using PrideTek.Shell.Common.Views.Services.MessageDialog;
using PrideTek.Shell.Core.Navigation;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

#pragma warning disable CS0168

namespace PrideTek.CustomerModule
{

    public class CustomerAddViewModel : BaseViewModel, ICustomerAddViewModel, INavigationAware, IRegionMemberLifetime
    {
        public string ViewTitle { get; set; }
        private CustomerWrapper _selectedItem;
        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand<string> CancelCommand { get; private set; }
        public DelegateCommand ResetCommand { get; private set; }
        public INavigationManager _navManager;
        public IGenericClientService _clientService;
        private IEventAggregator _eventAggregator { get; set; }

        private NavigationItem _navItem;

        private bool _isNewCustomer { get; set; }

        public CustomerAddViewModel(INavigationManager navManager, IGenericClientService clientService, IEventAggregator eventAggregator)
        {
            ViewTitle = "Add new customer";
            _clientService = clientService;
            _navManager = navManager;
            _eventAggregator = eventAggregator;
            _navItem = new NavigationItem();
            SaveCommand = new DelegateCommand(SaveEntity, ModelIsChanged);
            CancelCommand = new DelegateCommand<string>(CancelMethod);
            ResetCommand = new DelegateCommand(ResetEntity, ModelIsChanged);

            ComboStatesList = CollectionViewSource.GetDefaultView(ComboBoxData.States);



        }


        #region View's Property Members

        private bool ModelIsChanged()
        {
            return SelectedItem.IsChanged;
        }


        public CustomerWrapper SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                SetField(ref _selectedItem, value);
            }
        }
        #endregion

        #region Navigation Members
        public bool KeepAlive
        {
            get
            {
                return false;
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.NavigationService.Region.Context != null && navigationContext.NavigationService.Region.Context is CustomerWrapper)
            {
                SetSelectedItem((CustomerWrapper)navigationContext.NavigationService.Region.Context);
                ViewTitle = "Edit Customer View";
                navigationContext.NavigationService.Region.Context = null;
                _isNewCustomer = false;
            }
            else
            {
                SetSelectedItem(new CustomerWrapper(new Customer()));
                ViewTitle = "Add new Customer";
                //TabTitle = "Info";
                _isNewCustomer = true;
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        private void NavTo(string navPath)
        {
            _navItem.ScreenType = navPath;
            _navItem.ScreenRegion = RegionNames.ContentRegion;

            _navManager.NavigateTo(_navItem);
        }


        #endregion



        private async void SaveEntity()
        {
            try
            {
                await SaveAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to update Customer: Internal Error " + "The exception: " + ex.Message);
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
                        statusBarMsg = String.Format("{0} {1} was added as a new customer successfully", SelectedItem.FirstName, SelectedItem.LastName);
                    }
                    else
                    {
                        statusBarMsg = String.Format("Updated customer {0} {1} information successfully", SelectedItem.FirstName, SelectedItem.LastName);
                    }
                    _clientService.Update<Customer>(SelectedItem.Model);
                    SelectedItem.AcceptChanges();
                    _eventAggregator.GetEvent<StatusBarEvent>().Publish(statusBarMsg + DateTime.Now);
                });
            }
            catch (Exception ex)
            {
                if ((bool)SelectedItem.IsNew)
                {
                    statusBarMsg = String.Format("Failed to add new Customer {0} {1}", SelectedItem.FirstName, SelectedItem.LastName);
                }
                else
                {
                    statusBarMsg = String.Format("Failed to update {0} {1} info", SelectedItem.FirstName, SelectedItem.LastName);
                }

                _eventAggregator.GetEvent<StatusBarEvent>().Publish(statusBarMsg + DateTime.Now);
                SelectedItem.RejectChanges();
            }
        }

        private void CancelMethod(string navPath)
        {
            if (SelectedItem.IsChanged)
            {
                var messageBox = new MessageDialogService();
                var result = messageBox.ShowYesNoDialog("Close Tab?", "You will lose your changes if you close this tab.  Close it?", MessageDialogResult.No);

                if (result == MessageDialogResult.No)
                {
                    return;//if user click no, remind in that view.  
                }
            }

            NavTo(navPath);//Will navigate to a different view if the user click yes for the Yes or no MessageBox.
        }

        public void ResetEntity()
        {
            SelectedItem.RejectChanges();
        }


        private void SetSelectedItem(CustomerWrapper customerWrapper)
        {
            SelectedItem = customerWrapper;
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

        #region ComboBox Views Members
        public ICollectionView ComboStatesList { get; set; }

        public string ComboTextStates
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                ComboStatesList.Filter = item => item.ToString().ToLower().Contains(value.ToLower());
            }
        }

        #endregion

    }
}
