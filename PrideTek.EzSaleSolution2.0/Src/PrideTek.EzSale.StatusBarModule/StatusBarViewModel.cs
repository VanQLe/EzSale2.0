using PrideTek.EzSale.Infrastructure.Events;
using PrideTek.EzSale.StatusBarModule.Interfaces;
using PrideTek.Shell.Common.ViewModels;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrideTek.EzSale.StatusBarModule
{
    public class StatusBarViewModel: BaseViewModel,IStatusBarViewModel
    {
        private string _statusBarText;
        private string _busyIndicatorVisibility;

        public string StatusBarText
        {
            get
            {
                return _statusBarText;
            }

            set
            {
                SetField(ref _statusBarText, value);
            }
        }

        public string BusyIndicatorVisibility
        {
            get
            {
                return _busyIndicatorVisibility;
            }

            set
            {
                SetField(ref _busyIndicatorVisibility, value);
            }
        }

        public StatusBarViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<StatusBarEvent>().Subscribe(Update);
            //BusyIndicatorVisibility = "Visible";
        }

        private async void Update(string msg)
        {
            
            try
            {
                 await UpdateAsyn(msg);
                //throw new NullReferenceException();
            }
            catch (Exception)
            {

            }
        }
        private async Task UpdateAsyn(string msg)
        {
           // throw new NullReferenceException();
            try
            {
                await Task.Run(() =>
                {
                    StatusBarText = msg;
                    Thread.Sleep(4000);
                    StatusBarText = "";
                });

            }
            catch (Exception)
            {

            }
        }

    }
}
