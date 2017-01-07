using Microsoft.Practices.Unity;
using PrideTek.Shell.Core.Navigation;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.EzSale.Infrastructure
{
    public abstract class ModuleBase : IModule
    {
     
        public IRegionManager RegionManager { get; private set; }

        public IUnityContainer Container { get; private set; }
     
        public INavigationManager NavManager { get; private set; }

        public ModuleBase(INavigationManager navManager, IRegionManager regionManager, IUnityContainer container)
        {
            RegionManager = regionManager;
            NavManager = navManager;
            Container = container;
        }

        public void Initialize()
        {
            RegisterTypes();
            InitializeModule();
        }

        protected abstract void InitializeModule();

        protected abstract void RegisterTypes();

    }
}

