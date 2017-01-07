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
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PrideTek.CustomerModule
{
    public class CustomersViewModel : BaseViewModel, ICustomersViewModel, INavigationAware, IRegionMemberLifetime
    {
        private INavigationManager _navManager { get; set; }
        private NavigationItem _navItem { get; set; }
        private IEventAggregator _eventAggregator { get; set; }
        public DelegateCommand<string> NavCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand<CustomerWrapper> SelectedItemSelectedCommand { get; set; }
        private IGenericClientService _clientService { get; set; }


        private CustomerWrapper _selectedCustomer;
        private List<CustomerWrapper> _customerItems;
        private List<Customer> _customers;
        private ListCollectionView _customerCollection;

        //sorting
        private string _sortByPropertyValue;
        private string _sortByState;

        public CustomersViewModel(INavigationManager navManager, IGenericClientService clientService, IEventAggregator eventAggregator)
        {
            _navManager = navManager;
            _clientService = clientService;
            _navItem = new NavigationItem();
            NavCommand = new DelegateCommand<string>(NavTo);
            DeleteCommand = new DelegateCommand(DeleteSelectedItemsAsync);
            SortByPropertyValue = ComboBoxData.SortByPropertyValues[0];
            SortByState = ComboBoxData.SortByEntityState[0];
            SelectedItemSelectedCommand = new DelegateCommand<CustomerWrapper>(SelectedItemSelectedEvent);
            _eventAggregator = eventAggregator;


            Task.Run(async () =>  await ListAsync());
        }

        private async Task ListAsync()
        {
            try
            {
                await GetListAsync();//get the list

                if (Customers != null)
                {
                    SortCollectionAndFilter();//sort the collection before displaying
                }
                CustomerItems = Customers.Select((item) => new CustomerWrapper(item)).ToList();
                CustomerCollection = new ListCollectionView(CustomerItems);
            }
            catch (Exception)
            {
                _eventAggregator.GetEvent<StatusBarEvent>().Publish("Internal error while getting customers list");
            }

        }



        private async Task GetListAsync()
        {
            try
            {
                _eventAggregator.GetEvent<StatusBarEvent>().Publish("Getting Customer list");
                var customers = await Task<List<Customer>>.Run(() =>
                {

                    return _clientService.GetList<Customer>();
                });

                Customers = customers;
            }
            catch
            {
                _eventAggregator.GetEvent<StatusBarEvent>().Publish("Failed to get employees list");
            }
        }

        private async void DeleteSelectedItemsAsync()
        {
            var messageBox = new MessageDialogService();
            var msgResult = messageBox.ShowYesNoDialog("Warning!", "Are you sure you to delete selected item(s)?", MessageDialogResult.No);

            if (msgResult == MessageDialogResult.Yes)
            {
                try
                {
                    await DeleteCustomerAsync();
                    await ListAsync();
                }
                catch (Exception)
                {
                    _eventAggregator.GetEvent<StatusBarEvent>().Publish("Internal Error while deleing employees");
                }
            }

        }

        private async Task DeleteCustomerAsync()
        {
            await Task.Run(() =>
            {
                foreach (var customerWrapper in CustomerItems.ToList())
                {
                    if (customerWrapper.IsSelected)
                    {
                        if (customerWrapper != null)
                        {
                            string Name = customerWrapper.FirstName + " " + customerWrapper.LastName;
                            customerWrapper.IsDeleted = true;
                            _clientService.Delete<Customer>(customerWrapper.Model);
                            CustomerItems.Remove(customerWrapper);
                            _eventAggregator.GetEvent<StatusBarEvent>().Publish(Name + "was deleted");
                            Thread.Sleep(1000);
                        }
                    }
                }
            });
        }


        #region Property Members
        public string SortByPropertyValue
        {
            get
            {
                return _sortByPropertyValue;
            }

            set
            {
                _sortByPropertyValue = value;
            }
        }

        public string SortByState
        {
            get
            {
                return _sortByState;
            }

            set
            {
                _sortByState = value;
            }

        }
        public CustomerWrapper SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }

            set
            {
                SetField(ref _selectedCustomer, value);
            }
        }
        public List<CustomerWrapper> CustomerItems
        {
            get
            {
                return _customerItems;
            }

            set
            {
                SetField(ref _customerItems, value);
            }
        }

        public List<Customer> Customers
        {
            get
            {
                return _customers;
            }

            set
            {
                _customers = value;
            }
        }

        public ListCollectionView CustomerCollection
        {
            get
            {
                return _customerCollection;
            }

            set
            {
                _customerCollection = value;
            }
        }
        #endregion

        #region ViewModel navigation Members

        private void SelectedItemSelectedEvent(CustomerWrapper selectedItem)
        {
            SelectedCustomer = selectedItem;
            NavTo(ViewNames.CustomerAddView);
        }

        private void NavTo(string navPath)
        {
            _navItem.ScreenType = navPath;
            _navItem.ScreenRegion = RegionNames.ContentRegion;

            _navManager.NavigateTo(_navItem);
        }



        public bool KeepAlive
        {
            get
            {
                return false;
            }
        }



        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            SelectedCustomer = null;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            if (SelectedCustomer != null)
            {
                navigationContext.NavigationService.Region.Context = SelectedCustomer;
            }
        }

        #endregion


        #region Filter Methods
        private void SortCollectionAndFilter()
        {
            bool activeState = true;

            switch (SortByPropertyValue)
            {
                case "First Name":
                    Customers = Customers.OrderBy(o => o.FirstName).ToList();
                    break;
                case "Last Name":
                    Customers = Customers.OrderBy(o => o.LastName).ToList();
                    break;
                //case "Email":
                //    Customers = Customers.OrderBy(o => o.Email).ToList();
                //    break;
                //case "Work Phone":
                //    Customers = Customers.OrderBy(o => o.WorkPhone).ToList();
                //    break;
                //case "Cell Phone":
                //    Customers = Customers.OrderBy(o => o.CellPhone).ToList();
                //    break;
                //case "Code":
                //    Customers = Customers.OrderBy(o => o.CustomerCode).ToList();
                //    break;
            }

            switch (SortByState)
            {
                case "Active":
                    FilterCollection(activeState);
                    break;
                case "Deleted":
                    activeState = false;
                    FilterCollection(activeState);
                    break;
                default://return both active and deleted entities
                    break;
            }

        }

        public void FilterCollection(bool activeState)
        {
            if (Customers != null)
            {
                if (!activeState)
                {
                    foreach (var employee in Customers.ToList())
                    {
                        if (employee.IsDeleted == false)
                        {
                            Customers.Remove(employee);
                        }
                    }
                }
                else
                {
                    foreach (var employee in Customers.ToList())
                    {
                        if (employee.IsDeleted == true)
                        {
                            Customers.Remove(employee);
                        }
                    }
                }
            }

        }

        #endregion


    }
}
