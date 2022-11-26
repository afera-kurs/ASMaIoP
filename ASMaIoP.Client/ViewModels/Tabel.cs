using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Data;
using System.Globalization;

namespace ASMaIoP.Client.ViewModels
{
    //Класс для структирование данных в списке.
    public class TabelColumn
    {
        public int ID {get; set; }
        public string Employee {get; set;}
        public string Role {get; set;}
        public string Comes {get; set;}
        public string Leave {get; set;}
    }

    public class Tabel : INotifyPropertyChanged
    {
        //Создаём авто-свойства тк DataGrid отказваться считвать из листа.
        public List<TabelColumn> TabelColumn{get; set;}

        public Tabel()
        {
            TabelColumn = new List<TabelColumn>();
            instance = this;
        }

        private static Tabel instance;
        public static Tabel Instance
        {
            get=> instance;
            set 
            {
                MessageBox.Show("вы что дебилы свойтсво ломать!");
            }    
        }
        //Метод
        public void LoadTabel(DateTime? time)
        {       
            if(time == null) 
            {
                MessageBox.Show("Выберите дату идиоты!");
                return;
            }

            try
            {
                TabelColumn.Clear();
                //Создаем пакет
                Packet packet = new Packet();
                //Устанвливаем тип пакета
                packet.SetPacketType(PacketType.LOAD_TABEL);

                // Передаем в пакет идентефикатор текущей сесссии
                packet.AddInt(ApplicationAPIs.session.SessionId);

                // Открываем соедиение
                if(!ApplicationAPIs.session.Open())
                {
                    MessageBox.Show("лечите голову безголовые");
                    return;
                }
                //Форматируем дату под нужный формат
                string date = time?.ToString("yyyy-MM-dd");
                ApplicationAPIs.session.Write(packet.GetBytes());

                ApplicationAPIs.session.Write(date);

                int nCount = ApplicationAPIs.session.ReadInt();
                //Циклом записваем значение в класс
                for(int i = 0; i < nCount; i++)
                {
                    TabelColumn col = new TabelColumn();

                    col.ID  = ApplicationAPIs.session.ReadInt();
                    col.Employee = ApplicationAPIs.session.ReadString();
                    col.Role = ApplicationAPIs.session.ReadString();
                    col.Comes = ApplicationAPIs.session.ReadString();

                    int DateStatus = ApplicationAPIs.session.ReadInt();
                    if(DateStatus == 1)
                        col.Leave = ApplicationAPIs.session.ReadString();
                    else
                        col.Leave = "иди *****";

                    TabelColumn.Add(col);
                }

                // закрываем соединение с сервером
                ApplicationAPIs.session.Close();

                ASMaIoP.Client.View.Pages.TabelRight.Instance.TabelDataGrid.ItemsSource = null;
                ASMaIoP.Client.View.Pages.TabelRight.Instance.TabelDataGrid.ItemsSource = TabelColumn;
                ASMaIoP.Client.View.Pages.TabelRight.Instance.TabelDataGrid.UpdateLayout();
            }
            catch(Exception ex)
            {
                //Выводим сообщение об ошибке
                MessageBox.Show(ex.Message);
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
