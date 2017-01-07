using PrideTek.CustomerModule;
using PrideTek.CustomerModule.Interfaces;
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
    /// Interaction logic for CustomerAddView.xaml
    /// </summary>
    public partial class CustomerAddView : UserControl, IView
    {
        public CustomerAddView(ICustomerAddViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get
            {
               return  (IViewModel)DataContext;
            }

            set
            {
                DataContext = value;
            }
        }
    }
}
