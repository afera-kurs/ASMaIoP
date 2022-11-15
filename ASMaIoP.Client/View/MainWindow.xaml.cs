using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ASMaIoP.Client.Acrylic;
using ASMaIoP.Client.View;
using MahApps.Metro.Controls;
using System.Threading;
using System.IO;
using ASMaIoP.Client.ViewModels;
using ASMaIoP.Client.View.Pages;
using System; // EventArgs
using System.ComponentModel; // CancelEventArgs
using System.Windows; // window
using ASMaIoP.Models.Utilities;

namespace ASMaIoP.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private static MainWindow? instance;
        public static MainWindow Instance
        {
            get
            {
                instance = new MainWindow();

                return instance;
            }
        }

        public MainWindowVM ViewModel;

        public MainWindow()
        {
            ViewModel = new MainWindowVM(this);
            DataContext = ViewModel;
            //PhotoUsers.Fill;
            InitializeComponent();
            ArduinoAPI.SetCardReceiver(null);
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // грузись я сказал по хорошому иначе криворотова позову!
            ViewModel.WindowLoaded();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.LogOut();
        }

        bool _shown = true;

        private void MetroWindow_ContentRendered(object sender, EventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CCLeft.Content = new PageLeftCreater(this);
        }
        
        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            AuthWindow.Instance.Show();
        }

    }
}
