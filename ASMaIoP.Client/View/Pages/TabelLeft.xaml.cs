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
    /// Логика взаимодействия для TabelLeft.xaml
    /// </summary>
    public partial class TabelLeft : UserControl
    {
        
        public TabelLeft()
        {
            InitializeComponent();
            instance = this;
        }
        private static TabelLeft? instance;
        public static TabelLeft Instance
        {
            get
            {
                instance = new TabelLeft();

                return instance;
            }
        }

        private void DataPick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Tabel.Instance.LoadTabel(DataPick.SelectedDate);  
        }
    }
}
