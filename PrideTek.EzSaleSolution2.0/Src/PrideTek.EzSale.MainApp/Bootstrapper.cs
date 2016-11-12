using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using PrideTek.EmployeeModule;
using PrideTek.Shell.Core.Navigation;
using PrideTek.EzSale.ClientService;
using PrideTek.EzSale.DAL;
using Prism.Regions;
using System.Windows.Controls;
using PrideTek.EzSale.Infrastructure;
using PrideTek.EzSale.StatusBarModule;

namespace PrideTek.EzSale.MainApp
{
    public class Bootstrapper: UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            ModuleCatalog catalog = new ModuleCatalog();
            catalog.AddModule(typeof(EmployeeMod));
            catalog.AddModule(typeof(StatusBarMod));

            return catalog;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<INavigationManager, NavigationManager>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IGenericClientService, GenericClientService>();
            Container.RegisterType<IGenericRepository, GenericRepository>();
        }
        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            return mappings;
        }
    }
}
