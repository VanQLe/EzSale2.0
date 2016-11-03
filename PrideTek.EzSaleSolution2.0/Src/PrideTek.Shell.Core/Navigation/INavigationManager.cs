using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.Shell.Core.Navigation
{
    public interface INavigationManager
    {
        void NavigateTo(NavigationItem navItem);
    }
}
