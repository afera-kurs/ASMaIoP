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
using ASMaIoP.Client.ViewModels;

namespace ASMaIoP.Client.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MyProf.xaml
    /// </summary>
    public partial class MyProf : UserControl
    {
        Profile profile;
        public MyProf()
        {
            InitializeComponent();
            profile = Profile.Instance;
            DataContext = profile;
            profile.LoadData();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            profile.LoadCalendar(CalendarProf);
        }
    }
}
