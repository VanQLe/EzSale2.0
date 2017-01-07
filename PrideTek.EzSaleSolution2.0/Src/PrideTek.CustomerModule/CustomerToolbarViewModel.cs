using PrideTek.CustomerModule.Interfaces;
using PrideTek.EzSale.Infrastructure;
using PrideTek.Shell.Core.Navigation;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.CustomerModule
{
    public class CustomerToolbarViewModel: ICustomerToolbarViewModel
    {
        public string ViewHeader { get; set; }
        public DelegateCommand<string> NavCommand { get; set; }
        private NavigationItem _navItem;
        private INavigationManager _navManager;

        public CustomerToolbarViewModel(INavigationManager navManager)
        {
            ViewHeader = "Customers";
            NavCommand = new DelegateCommand<string>(NavTo);
            ApplicationCommands.NavContentRegCommand.RegisterCommand(NavCommand);

            _navManager = navManager;
            _navItem = new NavigationItem();
        }

        private void NavTo(string navPath)
        {
            _navItem.ScreenType = navPath;
            _navItem.ScreenRegion = RegionNames.ContentRegion;

            _navManager.NavigateTo(_navItem);
        }
    }
}
