﻿using PrideTek.EmployeeModule.Interfaces;
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

namespace PrideTek.EmployeeModule
{
    /// <summary>
    /// Interaction logic for EmployeeToolbarView.xaml
    /// </summary>
    public partial class EmployeeToolbarView : UserControl, IView
    {
        public EmployeeToolbarView(IEmployeeToolbarViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get
            {
                return (IEmployeeToolbarViewModel)DataContext;
            }

            set
            {
                DataContext = value;
            }
        }
    }
}
