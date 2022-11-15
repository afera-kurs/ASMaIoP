using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ASMaIoP.Client.View;
using ASMaIoP.Models;
using ASMaIoP.Models.Network;
using ASMaIoP.Models.Utilities;

namespace ASMaIoP.Client.ViewModels
{
    public class AuthVM
    {
        public string Login { get; set; }
        private string pass;

        public string Password
        {
            get => pass;
            set
            {
                this.pass = value;
            }
        }

        AuthWindow Parent;

        public AuthVM(AuthWindow Parent)
        {
            this.Parent = Parent;
            ArduinoAPI.SetCardReceiver(CardTrigger);
        }

        public void CardTrigger(string CardId)
        {
            try
            {
                CardId = CardId.Substring(0, CardId.Length - 1);
                if (ASMaIoP.Models.ApplicationAPIs.session.Auth(CardId, String.Empty, String.Empty))
                {
                    Parent.Dispatcher.Invoke(() =>
                    {
                        MainWindow.Instance.Show();
                        MainWindow.Instance.ViewModel.WindowLoaded();
                        Parent.Hide();
                    });
                }
                else
                    MessageBox.Show("Еблан лечи голову");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"[AuthVM.cs]:{ex.Message}");
            }
        }

        public void AuthCommand()
        {
            try
            {
                if (ASMaIoP.Models.ApplicationAPIs.session.Auth(String.Empty, pass, Login))
                {
                    MainWindow.Instance.Show();
                    Parent.Hide();
                }
                else
                    MessageBox.Show("Еблан лечи голову");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[AuthVM.cs]:{ex.Message}");
            }
        }

    }
}
