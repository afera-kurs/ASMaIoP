using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ASMaIoP.Models.Network
{
    internal class Client
    {
        string sIP;
        int nPort;
        TcpClient m_TCPClient;
        NetworkStream m_Stream;
        // Данный метод позволяет проверить является ли введенный аддресс доменом
        static public bool IsDomain(string sAddr)
        {
            // Данным циклом мы проходимся по введенному аддресу
            foreach (char cSym in sAddr)
            {
                // Если символ равен точки мы его пропускаем так как он есть как и в домене так и IP аддресе
                if (cSym == '.') continue;
                // Мы проверяем является ли символ буквой
                if (char.IsLetter(cSym))
                    return true;
            }
            return false;
        }
        // Данный метод позволяет установить адресс сервера к которому будет подключаться клиент
        public bool SetupAddress(string sAddr)
        {
            try
            {
                // Мы разделяем наш аддрес чтобы оттдельно получить IP и порт
                // Пример: 127.0.0.1:653
                string[] sAddr2 = sAddr.Split(':');
                // Поверяем является ли аддрес доменом
                sIP = sAddr2[0];
                // Парсим воторую часть строки в порт
                nPort = int.Parse(sAddr2[1]);
            }
            catch
            {
                return false;
            }
            return true;
        }
        // Данный метод нам позволяет произвести соединение с сервером
        public bool Connect()
        {
            try
            {
                // производим подключение
                this.m_TCPClient = new TcpClient(sIP, nPort);
                // получаем поток
                m_Stream = m_TCPClient.GetStream();
            }
            catch
            {
                return false;
            }

            return true;
        }
        // Данный метод позволяет разорвать соединение с сервером
        public void Close()
        {
            // закрываем поток
            m_Stream.Close();
            // закрываем соединение
            m_TCPClient.Close();
        }
        // Данный метод позволяет отправлять int переменную
        public void Write(int nData)
        {
            // конвертируем int в байты
            byte[] bytes = BitConverter.GetBytes(nData);
            // отправляем полученные байты клиенту
            m_Stream.Write(bytes, 0, sizeof(int));
        }
        // Данный метод позволяет считать int с клиента
        public int ReadInt()
        {
            // Резервируем байты для принятия данных
            byte[] data = new byte[sizeof(int)];
            // принимает байты с клиента
            m_Stream.Read(data, 0, sizeof(int));
            // конвертируем полуечнные данные в int
            return BitConverter.ToInt32(data, 0);
        }
        // Данный метод позволяет отправлять строку клиенту
        public void Write(string sData)
        {
            // конвертируем строку в байты
            byte[] data = Encoding.UTF8.GetBytes(sData);
            // получаем количество байт
            int nSize = data.Length;
            // отправляем размер строки клиенту
            Write(nSize);
            // отправляем байты строки клиенту
            m_Stream.Write(data, 0, data.Length);
        }
        // Данный метод позволяет принять 
        public string ReadString()
        {
            // Получаем размер строки у клиента
            int nSize = ReadInt();
            // резервируем память под строку
            byte[] data = new byte[nSize];
            // Получаем саму строку у клиента
            m_Stream.Read(data, 0, nSize);
            // Получаем конвертируем байты в строку
            return Encoding.UTF8.GetString(data);
        }

        public byte[] ReadBytes()
        {
            int nSize = ReadInt();
            byte[] data = new byte[nSize];
            m_Stream.Read(data, 0, nSize);
            return data;
        }

        public void Write(byte[] data)
        {
            // получаем количество байт
            int nSize = data.Length;
            // отправляем размер строки клиенту
            Write(nSize);
            // отправляем байты строки клиенту
            m_Stream.Write(data, 0, nSize);
        }

    }
}