using PrideTek.Shell.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Prism.Events;
using PrideTek.EzSale.Infrastructure.Events;
using PrideTek.Shell.Common.Views.Services.MessageDialog;

namespace PrideTek.EzSale.MainApp
{
    public class MainWindowViewModel : BaseViewModel, IMainWindowViewModel
    {
        private bool _ModelIsChanged;

        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<ModelIsChangedEvent>().Subscribe(ModelChanged);
        }

        private void ModelChanged(bool isChanged)
        {
            _ModelIsChanged = isChanged;
        }

        public void OnClosing(CancelEventArgs e)
        {
            if (_ModelIsChanged)
            {
                var messageBox = new MessageDialogService();
                var result = messageBox.ShowYesNoDialog("Close Tab?", "You will lose your changes if you close the program.  Close it?", MessageDialogResult.No);

                if (result == MessageDialogResult.No)
                {
                    e.Cancel = result == MessageDialogResult.No;
                }
            }
        }
    }
}
