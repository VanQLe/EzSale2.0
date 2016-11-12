using Microsoft.Practices.Unity;
using PrideTek.EzSale.Infrastructure;
using PrideTek.EzSale.StatusBarModule.Interfaces;
using PrideTek.Shell.Core.Navigation;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.EzSale.StatusBarModule
{
    public class StatusBarMod: ModuleBase
    {
        public StatusBarMod(INavigationManager navManager, IRegionManager regionManager, IUnityContainer container) : base(navManager, regionManager, container)
        {

        }

        protected override void InitializeModule()
        {
            IRegion region = RegionManager.Regions[RegionNames.StatusRegion];

            region.Add(Container.Resolve<StatusBarView>());

        }

        protected override void RegisterTypes()
        {
            //register view
            Container.RegisterTypeForNavigation<StatusBarView>();

            //register viewModel
            Container.RegisterType<IStatusBarViewModel, StatusBarViewModel>();
        }
    }
}
