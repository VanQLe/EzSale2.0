using Microsoft.Practices.Unity;
using PrideTek.EzSale.Infrastructure;
using PrideTek.Shell.Core.Navigation;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pridetek.SupportModule
{
    public class SupportMod : ModuleBase
    {
        public SupportMod(INavigationManager navManager, IRegionManager regionManager, IUnityContainer container) : base(navManager, regionManager, container)
        {

        }

        protected override void InitializeModule()
        {
            IRegion region = RegionManager.Regions[RegionNames.SupportRegion];


            region.Add(Container.Resolve<SupportView>());
        }

        protected override void RegisterTypes()
        {
            //Register view
           
        }
    }
}
