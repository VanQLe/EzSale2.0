using PrideTek.Shell.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PrideTek.EzSale.MainApp
{
    public interface IMainWindowViewModel : IViewModel
    {
        void OnClosing(CancelEventArgs e);
    }
}
