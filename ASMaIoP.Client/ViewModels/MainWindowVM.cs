using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;
using ASMaIoP.Models.Network;
using ASMaIoP.Client.Models.Network;
using ASMaIoP.Models;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;
using System.IO;
using ASMaIoP.Client.View;

namespace ASMaIoP.Client.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private string name = String.Empty;
        private string surName = String.Empty;
        private ImageSource currentUserPhoto;

        MainWindow Parent;

        public ImageSource CurrentUserPhoto
        {
            get => currentUserPhoto;

            set
            {
                currentUserPhoto = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(currentUserPhoto)));
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public string Surname
        {
            get => surName;
            set
            {
                surName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Surname)));
            }
        }

        public MainWindowVM(MainWindow wnd)
        {
            Parent = wnd;
        }

        public void LogOut()
        {
            //AuthWindow.Instance.Show();
            Parent.Close();
        }

        private void LoadProfileData(Packet packet)
        {
            PacketMath math = new PacketMath(1);
            
            int nNameSize = packet.GetInt(math.Counter);
            math.AddInt();

            int nSurNameSize = packet.GetInt(math.Counter);
            math.AddInt();
            
            Name = packet.GetString(math.Counter, nNameSize);
            math.AddBytes(nNameSize);

            Surname = packet.GetString(math.Counter, nSurNameSize);
            math.AddBytes(nSurNameSize);
            
            byte[] picutreBytes = packet.GetBytes(math.Counter, packet.GetBytes().Length);
            
            MemoryStream ms = new MemoryStream(picutreBytes);

            CurrentUserPhoto = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

        }

        public void WindowLoaded()
        {
            try
            {
                Packet packet = new Packet();
                packet.SetPacketType(PacketType.MAIN_WINDOW_LOADED);
                packet.AddInt(ApplicationAPIs.session.SessionId);

                if (!ApplicationAPIs.session.Open())
                {
                    MessageBox.Show("иди лечи голову: сервер не запушен");
                }

                ApplicationAPIs.session.Write(packet.GetBytes());

                packet.ReWrite(ApplicationAPIs.session.ReadBytes());
                ApplicationAPIs.session.Close();

                LoadProfileData(packet);
            }
            catch (Exception ex)
            {
                ApplicationAPIs.session.Close();
                MessageBox.Show($"иди лечи голову:{ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
