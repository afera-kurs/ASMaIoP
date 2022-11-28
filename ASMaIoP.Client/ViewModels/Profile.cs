using System;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using ASMaIoP.Client.View.Pages;
using ASMaIoP.Client.Models.Utilities;
using ASMaIoP.Models.Utilities;
using ASMaIoP.Models.Network;
using ASMaIoP.Client.Models.Network;
using ASMaIoP.Models;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Windows;
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
using System.Data;

namespace ASMaIoP.Client.ViewModels
{
    public class Profile : INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        private string surname;

        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Surname)));
            }
        }

        private string role;

        public string Role
        {
            get => role;
            set
            {
                role = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Role)));
            }
        }
        private int salary = 0;

        public int Salary
        { 
            get => salary;
            set
            {
                salary = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Salary)));
            }
        }

        private ImageSource profileImage;

        public ImageSource ProfileImage
        {
            get => profileImage;
            set
            {
                profileImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProfileImage)));
            }
        }

        public List<string> workedDates;

        private static Profile instance;

        public static Profile Instance
        {
            get
            {
                return instance;
            }
        }

        public static void CreateNewInstance()
        {
            instance = new Profile();
        }

        public Profile()
        {
            workedDates = new List<string>();
            ProfileImage = MainWindow.GetInstance.ViewModel.CurrentUserPhoto;
            Name = MainWindow.GetInstance.ViewModel.Name;
            Surname = MainWindow.GetInstance.ViewModel.Surname;
            instance = this;
        }

        public void LoadData()
        {
            try
            {
                Packet packet = new Packet();
                packet.SetPacketType(PacketType.LOAD_MY_PROFILE);
                packet.AddInt(ApplicationAPIs.session.SessionId);

                if (!ApplicationAPIs.session.Connect())
                {
                    MessageBox.Show("Будте добры предоставте мне соединение К СЕРВЕРУ!");
                    return;
                }

                ApplicationAPIs.session.Write(packet.GetBytes());

                Role = ApplicationAPIs.session.ReadString();
                Salary = ApplicationAPIs.session.ReadInt();

                int nDaysCount = ApplicationAPIs.session.ReadInt();

                for (int i = 0; i < nDaysCount; i++)
                {
                    workedDates.Add(ApplicationAPIs.session.ReadString());
                }

                ApplicationAPIs.session.Close();

            }
            catch (Exception ex)
            {
                ApplicationAPIs.session.Close();
                MessageBox.Show($"Иди фикси ошибку:\n{ex.Message}") ;
                return;   
            }
        }

        public void LoadCalendar(Calendar target)
        {
            foreach(string day in workedDates)
            {
                //target.BlackoutDates.Add(DateTime.Parse(day));
                target.BlackoutDates.Add(new CalendarDateRange(DateTime.Parse(day)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
