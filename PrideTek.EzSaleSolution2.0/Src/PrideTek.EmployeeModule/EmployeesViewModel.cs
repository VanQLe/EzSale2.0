using PrideTek.EmployeeModule.Interfaces;
using PrideTek.EzSale.ClientService;
using PrideTek.EzSale.Infrastructure;
using PrideTek.EzSale.Models.Entities;
using PrideTek.Shell.Common.ViewModels;
using PrideTek.Shell.Core.Navigation;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PrideTek.EmployeeModule
{
    public class EmployeesViewModel : BaseViewModel, IEmployeesViewModel, INavigationAware, IRegionMemberLifetime
    {
        public string ViewHeader { get; set; }
        private INavigationManager _navManager { get; set; }
        private NavigationItem _navItem { get; set; }

        public DelegateCommand<string> NavCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }

        private IGenericClientService _clientService { get; set; }

        private Employee SelectedEmployee { get; set; }
        public EmployeesViewModel(INavigationManager navManager, IGenericClientService clientService, IEventAggregator eventAggregator)
        {
            ViewHeader = "Employees";
            _navManager = navManager;
            _clientService = clientService;
            _navItem = new NavigationItem();
            NavCommand = new DelegateCommand<string>(NavTo);
            DeleteCommand = new DelegateCommand(DeleteSelectedItems);

            GetList();
            SelectedItemChangedCommand = new DelegateCommand<Employee>(SelectedItemChangedEvent);
        }

        private void DeleteSelectedItems()
        {
            if(MessageBox.Show("Are you sure to delete selected item(s)?","Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                foreach (var item in EmployeeItems.ToList())
                {
                    if (item.IsSelected)
                    {
                        if (item != null)
                        {
                            string Name = item.Employee.FirstName + " " + item.Employee.LastName;
                            _clientService.Delete<Employee>(item.Employee);
                            EmployeeItems.Remove(item);
                            MessageBox.Show(Name + " was deleted");
                        }
                    }
                }
            }
            GetList();
        }

        #region Display Employee list content
        public DelegateCommand<Employee> SelectedItemChangedCommand { get; set; }

        private ListCollectionView _employeeCollection;
        public ListCollectionView EmployeeCollection
        {
            get
            {
                return _employeeCollection;
            }

            set
            {
                SetField(ref _employeeCollection, value);
            }
        }
        private List<EmployeeItem> _employeeItems;
        public List<EmployeeItem> EmployeeItems
        {
            get
            {
                return _employeeItems;
            }
            set
            {
                SetField(ref _employeeItems, value);
            }
        }

        public List<Employee> Employees
        {
            get
            {
                return _employees;
            }

            set
            {
                _employees = value;
            }
        }



        private List<Employee> _employees;

        private void GetList()
        {
            Employees = _clientService.GetList<Employee>();
            EmployeeItems = Employees.Select((item) => new EmployeeItem() { Employee = item, IsSelected=false }).ToList();
            EmployeeCollection = new ListCollectionView(EmployeeItems);
        }

        private void SelectedItemChangedEvent(Employee selectedItem)
        {
            //SelectedEmployee = new Employee();
            SelectedEmployee = selectedItem;
            NavTo(ViewNames.EmployeeAddView);//nav to EmployeeAddView
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            SelectedEmployee = null;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            if (SelectedEmployee != null)
            {
                navigationContext.NavigationService.Region.Context = SelectedEmployee;
            }
        }


        private string _statusBarText;
        public string StatusBarText
        {
            get { return _statusBarText; }
            set
            {
                SetField(ref _statusBarText, value);
            }
        }

        #endregion
        public bool KeepAlive
        {
            get
            {
                return false;
            }
        }

        private void NavTo(string navPath)
        {
            _navItem.ScreenType = navPath;
            _navItem.ScreenRegion = RegionNames.ContentRegion;

            _navManager.NavigateTo(_navItem);
        }


    }
}
