using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ASMaIoP.Client.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageLeftCreater.xaml
    /// </summary>
    public partial class PageLeftCreater : System.Windows.Controls.UserControl
    {
        MainWindow parent;

        public PageLeftCreater(MainWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parent.CCRight.Content = new PageRightCreateProf();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            parent.CCRight.Content = new PageRightCreateJob();
        }
    }
}
