using PrideTek.EzSale.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PrideTek.Shell.Core.Navigation;
using Prism.Regions;
using PrideTek.EmployeeModule.Interfaces;
using Prism.Unity;

namespace PrideTek.EmployeeModule
{
    public class EmployeeMod : ModuleBase
    {
        public EmployeeMod(INavigationManager navManager, IRegionManager regionManager, IUnityContainer container) : base(navManager, regionManager, container)
        {
        }

        protected override void InitializeModule()
        {
            IRegion region = RegionManager.Regions[RegionNames.ToolbarRegion];

            region.Add(Container.Resolve<EmployeeToolbarView>());
        }

        protected override void RegisterTypes()
        {
            //Register views
            Container.RegisterTypeForNavigation<EmployeesView>();
            Container.RegisterTypeForNavigation<EmployeeAddView>();

            //Register ViewModels
            Container.RegisterType<IEmployeeToolbarViewModel, EmployeeToolbarViewModel>();
            Container.RegisterType<IEmployeesViewModel, EmployeesViewModel>();
            Container.RegisterType<IEmployeeAddViewModel, EmployeeAddViewModel>();
        }
    }
}
