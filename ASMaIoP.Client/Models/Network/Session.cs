using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMaIoP.Models.Network
{
    enum ProtocolId
    {
        Auth = 0
    }

    internal class Session : ASMaIoP.Models.Network.Client
    {
        //Вычисление хэша строки и возрат его из метода
        static string sha256(string randomString)
        {
            //Тут происходит криптографическая магия. Смысл данного метода заключается в том, что строка залетает в метод
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        public Session(string Address)
        {
            SetupAddress(Address);//Устанавливаем адрес сесии
        }

        public bool Open() => Connect(); // Открываем соедение с сервером

        int nSessionId = 0;
        int nLvlId = 0;

        public int SessionId { get => nSessionId; }//Свойства для чтение
        public int AccessLevel { get => nLvlId; }//Свойства для чтение

        public bool Auth(string CardId, string Password, string Login)
        {
            Packet packet = new Packet();
            packet.SetPacketType(PacketType.AUTH);
            if (CardId.Length > 0)
            {
                packet.AddByte(1);
                CardId = sha256(CardId);
                packet.AddString(CardId);
            }
            else
            {
                Password = sha256(Password);
                packet.AddByte(0);
                byte[] LoginBytes = Encoding.ASCII.GetBytes(Login);
                byte[] PasswordBytes = Encoding.ASCII.GetBytes(Password);
                packet.AddInt(LoginBytes.Length);
                packet.AddInt(PasswordBytes.Length);
                packet.AddBytes(LoginBytes);
                packet.AddBytes(PasswordBytes);
            }

            if (!Open()) //Провереям смогли мы подключиться
            {
                return false;
            }

            Write(packet.GetBytes());

            packet.ReWrite(ReadBytes());

            Close();

            // 0(byte) - type
            // 1(int start) - nStatusCode
            // 2 - nStatusCode
            // 3 - nStatusCode
            // 4(int end) - nStatusCode
            // 5(int start) - nSessionId
            // 6 - nSessionId
            // 7 - nSessionId
            // 8(int end) - nSessionId
            int nStatusCode = packet.GetInt(1);
            if(nStatusCode == 1)
            {
                nSessionId = packet.GetInt(5);
                return true;
            }

            return false;
        }
    }
}
