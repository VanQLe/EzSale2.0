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

        private string _sortByPropertyValue;
        private string _sortByState;
        //private List<string>
        public EmployeesViewModel(INavigationManager navManager, IGenericClientService clientService, IEventAggregator eventAggregator)
        {
            ViewHeader = "Employees";
            _navManager = navManager;
            _clientService = clientService;
            _navItem = new NavigationItem();
            NavCommand = new DelegateCommand<string>(NavTo);
            DeleteCommand = new DelegateCommand(DeleteSelectedItems);
            SortByPropertyValue = ComboBoxData.SortByPropertyValues[0];
            SortByState = ComboBoxData.SortByEntityState[0];
            GetList();
            SelectedItemChangedCommand = new DelegateCommand<EmployeeWrapper>(SelectedItemChangedEvent);
        }

        private void DeleteSelectedItems()
        {
            if(MessageBox.Show("Are you sure to delete selected item(s)?","Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                foreach (var employeeWrapper in EmployeeItems.ToList())
                {
                    if (employeeWrapper.IsSelected)
                    {
                        if (employeeWrapper != null)
                        {
                            string Name = employeeWrapper./*.Employee.*/FirstName + " " + employeeWrapper./*.Employee.*/LastName;
                            employeeWrapper./*Employee.*/IsDeleted = true;
                            _clientService.Delete<Employee>(employeeWrapper.Model/*.Employee*/);
                            EmployeeItems.Remove(employeeWrapper);
                            MessageBox.Show(Name + " was deleted");
                        }
                    }
                }
            }
            GetList();
        }

        #region Display Employee list content
        public DelegateCommand<EmployeeWrapper> SelectedItemChangedCommand { get; set; }
        private EmployeeWrapper _selectedEmployee;
        public EmployeeWrapper SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { SetField(ref _selectedEmployee, value); }
        }
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
        private List<EmployeeWrapper> _employeeItems;
        public List<EmployeeWrapper> EmployeeItems
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
            Employees = new List<Employee>();
            Employees = _clientService.GetList<Employee>();
            //Employees = Employees.OrderBy(o => o.FirstName).ToList() ;

            if(Employees != null)
            {
                SortCollectionAndFilter();//sort the collection before displaying
            }
           
            //foreach (var employee in Employees)
            //{

            //}
            EmployeeItems = Employees.Select((item) => new EmployeeWrapper(item)).ToList();
            EmployeeCollection = new ListCollectionView(EmployeeItems);
        }

        private void SortCollectionAndFilter()
        {
            bool activeState = true;

            switch (SortByPropertyValue)
            {
                case "First Name":
                    Employees = Employees.OrderBy(o => o.FirstName).ToList();
                    break;
                case "Last Name":
                    Employees = Employees.OrderBy(o => o.LastName).ToList();
                    break;
                case "Email":
                    Employees = Employees.OrderBy(o => o.Email).ToList();
                    break;
                case "Work Phone":
                    Employees = Employees.OrderBy(o => o.WorkPhone).ToList();
                    break;
                case "Cell Phone":
                    Employees = Employees.OrderBy(o => o.CellPhone).ToList();
                    break;
                case "Employee Code":
                    Employees = Employees.OrderBy(o => o.PinCode).ToList();
                    break;
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
            if (Employees != null)
            {
                if (!activeState)
                {
                    foreach (var employee in Employees.ToList())
                    {
                        if (employee.IsDeleted == false)
                        {
                            Employees.Remove(employee);
                        }
                    }
                }
                else
                {
                    foreach (var employee in Employees.ToList())
                    {
                        if (employee.IsDeleted == true)
                        {
                            Employees.Remove(employee);
                        }
                    }
                }
            }
           
        }


       
        private void SelectedItemChangedEvent(EmployeeWrapper selectedItem)
        {
            //SelectedEmployee = new EmployeeWrapper();
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

       public string SortByPropertyValue
        {
            get
            {
                return _sortByPropertyValue;
            }
            set
            {
                SetField(ref _sortByPropertyValue, value);
                GetList();
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
                SetField(ref _sortByState, value);
                GetList();
            }
            
        }
    }
}
