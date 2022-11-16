using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;
using ASMaIoP.Models.Network;
using ASMaIoP.Client.Models.Network;
using ASMaIoP.Models;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;
using ASMaIoP.Client.View;
using System.Windows.Data;
using ASMaIoP.Client.View.Pages;
using ASMaIoP.Client.Models.Utilities;
using ASMaIoP.Models.Utilities;

namespace ASMaIoP.Client.ViewModels
{
    internal class EmployeeInfo
    {
        public int EmployeeId;
        public string Name;
        public string Surname;
        public int jodId;
    }

    internal class JobInfo
    {
        public string JobName;
        public int JobId;

        public int LocalId;
    }

    internal class CreateProf : INotifyPropertyChanged
    {
        public string Name;
        public string Surname;
        public string cardID;

        private int jodId;
        private string jobName;

        List<EmployeeInfo> employees = new List<EmployeeInfo>();
        List<JobInfo> JobsInfo = new List<JobInfo>();

        private PageRightCreateProf parent;

        public CreateProf(PageRightCreateProf parent)
        {
            this.parent = parent; 
        }

        public int JodId
        {
            set
            {
                jodId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(JodId)));
            }
            get { return jodId; }
        }                    
        
        public string JobName
        {
            set
            {
                jobName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(JodId)));
            }
            get { return jobName; }
        }

        public string CardID
        {
            set
            {
                jobName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CardID)));
            }
            get { return jobName; }
        }


        public void ReadCard(string _cardID)
        {
            CardID = _cardID;
        }

        public void EnableCardRecvining(bool Enable)
        {
            ArduinoAPI.SetCardReceiver(Enable? ReadCard : null);
        }

        public void EditUser(int UserId, int JobId, string Name, string Surname)
        {
            Packet packet = new Packet();
            //устанавливаем тип пакета
            packet.SetPacketType(PacketType.CREATE_PROF_EditUser);
            //добавляем в пакет айди текущей сессии
            packet.AddInt(ApplicationAPIs.session.SessionId);
            //Добавляем в пакет айди пользователя которого мы хотим удалить
            packet.AddInt(UserId);

            //открываем соединение с сервером
            if (!ApplicationAPIs.session.Open())
            {
                MessageBox.Show("лечи голову");
            }

            //Отпрвляем хедер покета
            ApplicationAPIs.session.Write(packet.GetBytes());

            ApplicationAPIs.session.Write(JobId);
            ApplicationAPIs.session.Write(Name);
            ApplicationAPIs.session.Write(Surname);

            //считываем получилось ли удалить пользователя
            int bIsSuccesss = ApplicationAPIs.session.ReadInt();

            // проверяем успешно ли пользователь отредактирован
            if (bIsSuccesss == 1)
            {
                MessageBox.Show("Пользователь успешно изменён!");
            }
            else
            {
                MessageBox.Show("Ошибка не удолось изменить данные пользователя!");
            }

            //закрываем соединение
            ApplicationAPIs.session.Close();
        }

        public void DeleteUser(int UserId)
        {
            Packet packet = new Packet();
            //устанавливаем тип пакета
            packet.SetPacketType(PacketType.CREATE_PROF_DELETE_USER);
            //добавляем в пакет айди текущей сессии
            packet.AddInt(ApplicationAPIs.session.SessionId);
            //Добавляем в пакет айди пользователя которого мы хотим удалить
            packet.AddInt(UserId);


            //открываем соединение с сервером
            if (!ApplicationAPIs.session.Open())
            {
                MessageBox.Show("лечи голову");
            }

            //Отпрвляем хедер покета
            ApplicationAPIs.session.Write(packet.GetBytes());

            //считываем получилось ли удалить пользователя
            int bIsSuccesss = ApplicationAPIs.session.ReadInt();

            // проверяем успешно ли пользователь удален
            if (bIsSuccesss == 1)
            {
                MessageBox.Show("Пользователь успешно удален!");
            }
            else
            {
                MessageBox.Show("Ошибка не удолось удалить пользователя!");
            }

            //закрываем соединение
            ApplicationAPIs.session.Close();
        }

        public void CreateUser(int JobId, string Name, string Surname, string Login, string Password, string CardId, string FirstWorkDay)
        {
            Packet packet = new Packet();
            //устанавливаем тип пакета
            packet.SetPacketType(PacketType.CREATE_PROF_USER);
            //добавляем в пакет айди текущей сессии
            packet.AddInt(ApplicationAPIs.session.SessionId);

            //открываем соединение с сервером
            if (!ApplicationAPIs.session.Open())
            {
                MessageBox.Show("лечи голову");
            }

            //Отпрвляем хедер покета
            ApplicationAPIs.session.Write(packet.GetBytes());

            // отправляем остальные данные для пакета
            ApplicationAPIs.session.Write(JobId);
            ApplicationAPIs.session.Write(Name);
            ApplicationAPIs.session.Write(Surname);
            ApplicationAPIs.session.Write(Login);
            ApplicationAPIs.session.Write(Password);
            ApplicationAPIs.session.Write(CardId);
            ApplicationAPIs.session.Write(FirstWorkDay);
                
            //считываем получилось ли создать пользователя
            int bIsSuccesss = ApplicationAPIs.session.ReadInt();
            
            // проверяем успешно ли пользователь создан
            if(bIsSuccesss == 1)
            {
                MessageBox.Show("Пользователь успешно создан!");
            }
            else
            {
                MessageBox.Show("Ошибка не удолось создать пользователя!");
            }

            // закрываем соединение с сервером
            ApplicationAPIs.session.Close();
        }

        public void GetUsers()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FullName");
            dt.Columns.Add("Id");
            dt.Columns.Add("LocalId");

            Packet packet = new Packet();
            //устанавливаем тип пакета
            packet.SetPacketType(PacketType.CREATE_PROF_USERS);
            //добавляем в пакет айди текущей сессии
            packet.AddInt(ApplicationAPIs.session.SessionId);

            //открываем соединение с сервером
            if (!ApplicationAPIs.session.Open())
            {
                MessageBox.Show("лечи голову");
            }

            //Отпрвляем хедер покета
            ApplicationAPIs.session.Write(packet.GetBytes());

            // получаем количество работников
            int nCountEmployee = ApplicationAPIs.session.ReadInt();

            // заходим в цикл чтобы получить всех работников
            for (int i = 0; i < nCountEmployee; i++)
            {
                //Получаем id рабочего
                int EmployeeId = ApplicationAPIs.session.ReadInt();
                //получаем имя работника
                string Name = ApplicationAPIs.session.ReadString();
                // получем фамилию работника
                string Surname = ApplicationAPIs.session.ReadString();
                // получаем его должность
                int JobId = ApplicationAPIs.session.ReadInt();
                // добовляем его в лист

                employees.Add(new EmployeeInfo { EmployeeId = EmployeeId, Name = Name, Surname = Surname, jodId = JobId });

                DataRow dr = dt.NewRow();
                dr["FullName"] = $"{Name} {Surname}";
                dr["Id"] = EmployeeId;
                dr["LocalId"] = employees.Count - 1;

                dt.Rows.Add(dr);
            }

            // закрываем соединение с сервером
            ApplicationAPIs.session.Close();


            parent.UserTumbler.DataContext = dt;
            parent.UserTumbler.DisplayMemberPath = dt.Columns[0].ToString();

        }

        public void FormLoaded()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Id");
            dt.Columns.Add("LocalId");

            Packet packet = new Packet();
            //устанавливаем тип пакета
            packet.SetPacketType(PacketType.CREATE_PROF);
            //добавляем в пакет айди текущей сессии
            packet.AddInt(ApplicationAPIs.session.SessionId);

            //открываем соединение с сервером
            if (!ApplicationAPIs.session.Open())
            {
                MessageBox.Show("лечи голову");
            }

            //Отпрвляем хедер покета
            ApplicationAPIs.session.Write(packet.GetBytes());
            // Получаем количство должностей
            int nCountRoles = ApplicationAPIs.session.ReadInt();

            //получаем все должности
            for(int i = 0; i < nCountRoles; i++)
            {
                //получаем Id долнжости
                int JobId = ApplicationAPIs.session.ReadInt();
                //получаем название должности
                string JobName = ApplicationAPIs.session.ReadString();
                //сохраняем информацию о должности в List
                JobsInfo.Add(new JobInfo { JobId = JobId, JobName = JobName, LocalId = dt.Rows.Count });

                DataRow dr = dt.NewRow();
                dr["Name"] = JobName;
                dr["Id"] = JobId;
                dr["LocalId"] = JobsInfo.Count - 1;
                dt.Rows.Add(dr);
            }

            // закрываем соединение с сервером
            ApplicationAPIs.session.Close();

            parent.cmbAbility.DataContext = dt;
            parent.cmbAbility.DisplayMemberPath = dt.Columns[0].ToString();

            GetUsers();
        }

        public void LoadUser(int j)
        {
            parent.NameBox.Text = employees[j].Name;
            parent.SurnameBox.Text = employees[j].Surname;
            for (int i = 0; i < JobsInfo.Count; i++)
            {
                if(JobsInfo[i].JobId == employees[j].jodId)
                {
                    parent.cmbAbility.SelectedIndex = JobsInfo[i].LocalId;
                    return;
                }
            }
        }

        public static string GenLogin(string name, string surname)
        {
            string Fullname = name + surname;
            string RawLogin = Strings.cyr2lat(Fullname);
            Random rnd = new Random();
            for (int i = 0; i < 3; i++) RawLogin += (char)rnd.Next();
            return RawLogin;
        }

        public static string GenPassword()
        {
            Random rnd = new Random();
            string RawPassword = "";
            for (int i = 0; i < 8; i++) RawPassword += (char)rnd.Next();

            return RawPassword;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
