using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMaIoP.Models.Utilities;
using ASMaIoP.Models.Network;

using System.Windows;

namespace ASMaIoP.Models
{
    internal class ApplicationAPIs
    {
        static private Config applicationConfiguration = new Config();
        
        static private string ServerAddr = "";

        static public bool IsPortOpen = false;

        static public Session session;

        static public bool ApplicationStart()
        {
            try
            {
                bool res = applicationConfiguration.ParseFromFile("client.cfg");
                if(!res)    
                {
                    return false;
                }

                if (applicationConfiguration.ContaintsVariable("server_address"))
                {
                    ServerAddr = applicationConfiguration["server_address"];
                    session = new Session(ServerAddr);
                }
                else
                {
                    return false;
                }

                if (applicationConfiguration.ContaintsVariable("serial_port"))
                {
                    string Port = applicationConfiguration["serial_port"];
                    IsPortOpen = ArduinoAPI.UsePort(Port);
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }


        public static void ApplicationExit()
        {
            if(IsPortOpen) ArduinoAPI.Shutdown();
        }
     
    }
}
