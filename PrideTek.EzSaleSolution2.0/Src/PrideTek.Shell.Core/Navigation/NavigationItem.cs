using PrideTek.Shell.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.Shell.Core.Navigation
{
    public class NavigationItem
    {
        public string ScreenId { get; set; }

        public string ScreenType { get; set; }

        public string ScreenRegion { get; set; }

        public IScreenView ScreenView { get; set; }

        public IScreenViewModel ScreenViewModel { get; set; }
    }
}
