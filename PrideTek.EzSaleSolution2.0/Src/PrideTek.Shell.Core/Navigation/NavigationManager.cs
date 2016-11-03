using Microsoft.Practices.Unity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.Shell.Core.Navigation
{
    public class NavigationManager : INavigationManager
    {
        private IRegionManager _regionManager { get; set; }
        private IUnityContainer _container { get; set; }
        public NavigationManager(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void NavigateTo(NavigationItem navItem)
        {
            string region = navItem.ScreenRegion;
            string type = navItem.ScreenType;

            _regionManager.RequestNavigate(region, type);
        }
    }
}
