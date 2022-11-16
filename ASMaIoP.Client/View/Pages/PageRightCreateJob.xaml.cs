using System;
using System.Collections.Generic;
using System.Data;
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
using ASMaIoP.Models.Utilities;
using ControlzEx.Standard;

namespace ASMaIoP.Client.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageRightCreateJob.xaml
    /// </summary>
    public partial class PageRightCreateJob : UserControl
    {
        EditJob jobs = null;
        public PageRightCreateJob()
        {
            InitializeComponent();
            jobs = new EditJob();
            jobs.FormLoaded();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            DataRowView v = (DataRowView)LvlAccess.SelectedValue;
            int i = int.Parse((string)v.Row.ItemArray[1]);
            bool result = int.TryParse(Salary.Text, out var salary);
            if (result == true)
                jobs.CreateJobs(i, NameJob.Text, salary);
            else
                MessageBox.Show($"Проверьте введенное значение для пункта зарплата. Оно не корректно: {Salary.Text}");
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Save.Visibility = Visibility.Visible;
            ProfTumbler.Visibility = Visibility.Visible;
            Delete.Visibility = Visibility.Visible;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView v = (DataRowView)ProfTumbler.SelectedValue;
            int i = int.Parse((string)v.Row.ItemArray[1]);
        }
    }
}
