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
using PrideTek.CustomerModule;
using Pridetek.SupportModule;
using Serilog;

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
            catalog.AddModule(typeof(CustomerMod));
            catalog.AddModule(typeof(SupportMod));
            return catalog;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<INavigationManager, NavigationManager>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IGenericClientService, GenericClientService>();
            Container.RegisterType<IGenericRepository, GenericRepository>();
            Container.RegisterType<IMainWindowViewModel, MainWindowViewModel>();



            //Instantiate logger

            //const string customerTemplate = "Log message {Timestamp:yyyy-MMM-dd-HH:mm}[{Level}]{Message}{NewLine}{Exception}";

            //.WriteTo.File("Logfile.txt", outputTemplate: customerTemplate, fileSizeLimitBytes:100);//set the size of the file
            //.WriteTo.RollingFile("rollinglogfile.txt");
            //.WriteTo.File("Logfile.txt", outputTemplate: customerTemplate, fileSizeLimitBytes:null)//use template and no file size limit.
            //.WriteTo.RollingFile("RollingLogfile.txt", outputTemplate: customerTemplate, fileSizeLimitBytes:null,retainedFileCount:31); //Limit how many rolling files will be saved before deleting the oldest file to add the newest file.
            //

            //ILogger logger = new LoggerConfiguration()
            //                        .WriteTo.RollingFile("RollingLogfile.txt", outputTemplate: customerTemplate, fileSizeLimitBytes:null)//use template and no file size limit.
            //                        .CreateLogger();

            //Log.Logger = logger;
        }
        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            return mappings;
        }
    }
}
