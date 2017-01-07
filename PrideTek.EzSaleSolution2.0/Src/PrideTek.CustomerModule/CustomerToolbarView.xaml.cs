using PrideTek.CustomerModule.Interfaces;
using PrideTek.EmployeeModule.Interfaces;
using PrideTek.Shell.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrideTek.CustomerModule
{
    /// <summary>
    /// Interaction logic for CustomerToolbarView.xaml
    /// </summary>
    public partial class CustomerToolbarView : UserControl, IView
    {
        public CustomerToolbarView(ICustomerToolbarViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get
            {
                return (ICustomerToolbarViewModel)DataContext;
            }

            set
            {
                DataContext = value;
            }
        }
    }
}
