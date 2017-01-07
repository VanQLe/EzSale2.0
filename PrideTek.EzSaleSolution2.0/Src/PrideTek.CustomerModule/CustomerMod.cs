using Microsoft.Practices.Unity;
using PrideTek.CustomerModule;
using PrideTek.CustomerModule.Interfaces;
using PrideTek.EmployeeModule.Interfaces;
using PrideTek.EzSale.Infrastructure;
using PrideTek.Shell.Core.Navigation;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.CustomerModule
{
    public class CustomerMod: ModuleBase
    {
        public CustomerMod(INavigationManager navManager, IRegionManager regionManager, IUnityContainer container) : base(navManager, regionManager, container)
        {

        }
        protected override void InitializeModule()
        {
            IRegion region = RegionManager.Regions[RegionNames.ToolbarRegion];
            region.Add(Container.Resolve<CustomerToolbarView>());
        }

        protected override void RegisterTypes()
        {
            //Views
            Container.RegisterTypeForNavigation<CustomersView>();
            Container.RegisterTypeForNavigation<CustomerAddView>();

            //ViewModels
            Container.RegisterType<ICustomerToolbarViewModel, CustomerToolbarViewModel>();
            Container.RegisterType<ICustomersViewModel, CustomersViewModel>();
            Container.RegisterType<ICustomerAddViewModel, CustomerAddViewModel>();
        }

    }
}
