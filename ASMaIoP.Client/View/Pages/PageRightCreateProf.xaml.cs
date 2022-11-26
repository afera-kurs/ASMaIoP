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

namespace ASMaIoP.Client.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageRightCreateProf.xaml
    /// </summary>
    public partial class PageRightCreateProf : UserControl
    {
        CreateProf prof = null;
        
        public PageRightCreateProf()
        {
            prof = new CreateProf(this);
            DataContext = prof;

            InitializeComponent();
            prof.FormLoaded();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView v = (DataRowView)cmbAbility.SelectedValue;
            int i = int.Parse((string)v.Row.ItemArray[1]);
            string Pass = CreateProf.GenPassword();
            string Login = CreateProf.GenLogin(NameBox.Text, SurnameBox.Text);

            prof.CreateUser(i, NameBox.Text, SurnameBox.Text, Login, Pass, CardStatys.Text, "1991.09.11");
            
        }
        private void cmbAbility_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EdithUsers_Click(object sender, RoutedEventArgs e)
        {
            UserTumbler.Visibility = Visibility.Visible;
            ButtonSave.Visibility = Visibility.Visible;
            DeleteButton.Visibility = Visibility.Visible;
            CardsRecivedButton.Visibility = Visibility.Collapsed;
            CardTextBlock.Visibility = Visibility.Collapsed;
            CardStatys.Visibility = Visibility.Collapsed;
        }

        private void UserTumbler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            DataRowView v = (DataRowView)UserTumbler.SelectedValue;
            if (v is null) return;
            int i = int.Parse((string)v.Row.ItemArray[2]);

            prof.LoadUser(i);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            DataRowView v = (DataRowView)UserTumbler.SelectedValue;
            int i = int.Parse((string)v.Row.ItemArray[1]);

            v = (DataRowView)cmbAbility.SelectedValue;
            int IdAblity = int.Parse((string)v.Row.ItemArray[1]);
            prof.EditUser(i, IdAblity, NameBox.Text, SurnameBox.Text);
            
            prof.FormLoaded();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView v = (DataRowView)UserTumbler.SelectedValue;
            int i = int.Parse((string)v.Row.ItemArray[1]);

            prof.DeleteUser(i);
        }

        bool IsEnabled = false;
        private void CardsRecivedButton_Click(object sender, RoutedEventArgs e)
        {
            IsEnabled = !IsEnabled;
            prof.EnableCardRecvining(IsEnabled);
            CardStatys.Visibility = Visibility.Visible;
        }
    }
}
