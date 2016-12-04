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

namespace PrideTek.Shell.Common.Views.Services.MessageDialog
{
    /// <summary>
    /// Interaction logic for MessageDialog.xaml
    /// </summary>
    public partial class MessageDialog : Window
    {
        private MessageDialogResult _result;

        public MessageDialog(string title, string text, MessageDialogResult defaultResult, params MessageDialogResult[] buttons)
        {
            InitializeComponent();
            Title = title;
            textBlock.Text = text;
            InitializeButtons(buttons);
            _result = defaultResult;
        }

        private void InitializeButtons(MessageDialogResult[] buttons)
        {
            if (buttons == null || buttons.Length == 0)
            {
                buttons = new[] { MessageDialogResult.Ok };
            }

            foreach (var button in buttons)
            {
                var btn = new Button { Content = button, Tag = button };//set the name of the button
                ButtonsPanel.Children.Add(btn);//add the button to the buttonspanel
                btn.Click += ButtonClick;//set an event when that button is clicked
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var button = e.Source as Button;//get the button
            if(button != null)
            {
                _result = (MessageDialogResult)button.Tag;
                this.Close();//close the window once a button is clicked
            }
        }

        public new MessageDialogResult ShowDialog()
        {
            base.ShowDialog();
            return _result;
        }
    }
}
