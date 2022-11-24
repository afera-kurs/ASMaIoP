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
using MaterialDesignThemes.Wpf;

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
                        UpdateMainWindow();
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
                    UpdateMainWindow();
                }
                else
                    MessageBox.Show("Еблан лечи голову");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[AuthVM.cs]:{ex.Message}");
            }
        }

        private void UpdateMainWindow()
        {

            if (ASMaIoP.Models.ApplicationAPIs.session.AccessLevel >= 3)
            {
                MainWindow inst = MainWindow.Instance;
                inst.Show();
                inst.TopPanel.Visibility = Visibility.Visible;
                Parent.Hide();
            }
            else
            {
                MainWindow.Instance.Show();
            }
        }   

    }
}
