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
using ASMaIoP.Models;
using ASMaIoP.Client.ViewModels;

namespace ASMaIoP.Client.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MyProfileLeft.xaml
    /// </summary>
    public partial class MyProfileLeft : UserControl
    {
        Profile vm;

        public MyProfileLeft()
        {
            InitializeComponent();
            vm = Profile.Instance;
            DataContext = vm;
        }
    }
}
