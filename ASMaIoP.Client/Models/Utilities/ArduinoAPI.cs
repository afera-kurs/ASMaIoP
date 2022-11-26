using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows;


namespace ASMaIoP.Models.Utilities
{
    internal class ArduinoAPI
    {
        private static SerialPort CurrentArduionoPort = null;
        // Обьявляем делегата который будет вызываться при получении данных с сериал порта
        public static CardReceivedHandler cardReceivedHandler = null;

        public static bool UsePort(string sPortName)
        {
            // создаем экземпляр класса SerialPort
            CurrentArduionoPort = new SerialPort();
            // Устанавливаем Название порта который будем открывать
            CurrentArduionoPort.PortName = sPortName;
            // Скорость передачи в бодах
            CurrentArduionoPort.BaudRate = 9600;

            CurrentArduionoPort.DataReceived += port_DataReceived; // Присвайваем делегату метод port_DataReceived
            try
            {
                CurrentArduionoPort.Open(); //Открываем serial порт
            }
            catch
            {
                return false; //Возвращаем false если порт не удалось открыть
            }
            return true; //Возварщаем если всё успешно
        }

        public static void SetCardReceiver(CardReceivedHandler newHandler)
        {
            cardReceivedHandler = newHandler;
        }

        public static void Shutdown()
        {
            CurrentArduionoPort.Close();
        }

        public static CardReceivedHandler GetCurrentReceiver()
        {
            return cardReceivedHandler;
        }
        public static void port_DataReceived(object sender, SerialDataReceivedEventArgs e) //Стандартное событие для данных с SerialPort
        {
            try
            {
                string CardId = CurrentArduionoPort.ReadLine();// Считываем строку содержащую id карты из ардуинки
                cardReceivedHandler?.Invoke(CardId);// Передаем вызываем и передаем ее делегату
            }
            catch(Exception ex)
            {
                MessageBox.Show($"э ты что накуреный вот тебе еррор: {ex.Message}");
                return;
            }
        }

        public delegate void CardReceivedHandler(string CardId); //объявляем сигнатуру делигата принимающий ID карты пользвателя 
    }
}
