using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.Shell.Common.Views.Services.MessageDialog
{
    public interface IMessageDialogService
    {
        /// <summary>
        /// This is like a Messagebox.Show where you can pass in a title, text, and default value for a yes or no result messagebox.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text"></param>
        /// <param name="defaultResult"></param>
        /// <returns></returns>
        MessageDialogResult ShowYesNoDialog(string title, string text, MessageDialogResult defaultResult = MessageDialogResult.Yes);
    }
}
