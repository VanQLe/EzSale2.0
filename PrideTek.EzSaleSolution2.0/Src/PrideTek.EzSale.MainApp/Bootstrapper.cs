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

            return catalog;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<INavigationManager, NavigationManager>(new ContainerControlledLifetimeManager());
            //Container.RegisterType<IEmployeeToolbarViewModel, EmployeeToolbarViewModel>();
        }
    }
}
