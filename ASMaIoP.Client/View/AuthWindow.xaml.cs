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
using ASMaIoP.Client.Acrylic;
using ASMaIoP.Client.ViewModels;
using ASMaIoP.Models.Network;

namespace ASMaIoP.Client.View
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private static AuthWindow instance = null;

        public static AuthWindow Instance
        {
            get 
            {
                instance = new AuthWindow();

                return instance;
            }
        }
        
        public string Name;
        public AuthVM vm;

        public AuthWindow()
        {
            InitializeComponent();
            vm = new AuthVM(this);
            DataContext = vm; //Передаю контекст данных для отображения 
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DataContext = new WindowBlureffect(this) { BlurOpacity = 100 };
            WindowBlureffect eff = new WindowBlureffect(this) { BlurOpacity = 100 };
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //Сделать через овнера
            vm.AuthCommand();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        void PasswordChangedHandler(Object sender, RoutedEventArgs args)
        {
            vm.Password = PswBox.Password;
        }
    }
}
