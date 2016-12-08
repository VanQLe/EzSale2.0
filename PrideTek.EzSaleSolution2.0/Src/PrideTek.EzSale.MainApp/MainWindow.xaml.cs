using Microsoft.Practices.Unity;
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
using System.Windows.Shapes;
using System.ComponentModel;

namespace PrideTek.EzSale.MainApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMainWindowViewModel _viewModel;
        public MainWindow(IMainWindowViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            _viewModel.OnClosing(e);
        }

   
    }
}
