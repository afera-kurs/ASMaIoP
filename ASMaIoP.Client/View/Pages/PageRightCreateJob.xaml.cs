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
            jobs = new EditJob(this);
            jobs.FormLoaded();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            int i = LvlAccess.SelectedIndex + 1;
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
            int i = LvlAccess.SelectedIndex + 1;
            DataRowView v = (DataRowView)ProfTumbler.SelectedValue;
            int Id = int.Parse((string)v.Row.ItemArray[1]);
            string JobTitle = NameJob.Text;
            int nSalary = Int32.Parse(Salary.Text);
            jobs.edJob(Id, JobTitle, nSalary, i);
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView v = (DataRowView)ProfTumbler.SelectedValue;
            int i = int.Parse((string)v.Row.ItemArray[1]);

            List<EditJob.EmployeeInfo> emplyees = jobs.GetUsersDeleteJob(i);
            if(emplyees.Count > 0)
            {
                string EmpMessage = "";

                foreach(EditJob.EmployeeInfo inf in emplyees)
                {
                    EmpMessage += $"{inf.Name} {inf.Surname}\n";
                }

                MessageBox.Show($"Не возможно удалить выбранную должность из-за сотрудников занимающих её:\n {EmpMessage}");
            }

        }

        private void ProfTumbler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView v = (DataRowView)ProfTumbler.SelectedValue;
            int Id = int.Parse((string)v.Row.ItemArray[1]);

            jobs.LoadJob(Id);
        }

        private void LvlAccess_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
