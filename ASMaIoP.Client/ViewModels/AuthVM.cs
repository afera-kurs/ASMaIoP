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
        //Устанавливаем parent дабы связаться с окном
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
                //Парсим кард ID
                CardId = CardId.Substring(0, CardId.Length - 1);
                //Вызваем авторизации для карты
                if (ASMaIoP.Models.ApplicationAPIs.session.Auth(CardId, String.Empty, String.Empty))
                {   
                    Parent.Dispatcher.Invoke(() =>
                    {
                        //Обновляем главное окно
                        UpdateMainWindow();
                    });
                }
                else
                    MessageBox.Show("лечи голову");
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
                //Вызваем авторизации для логина и пароля
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
                MainWindow mW = MainWindow.Instance;
                mW.TopPanel.Visibility = Visibility.Visible;
                mW.Show();
                Parent.Close();
            }
            else
            {
                MainWindow.Instance.Show();
                Parent.Close();
            }
        }   

    }
}
