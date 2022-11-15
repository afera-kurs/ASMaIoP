using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ASMaIoP.Models;
using ASMaIoP.Models;

namespace ASMaIoP.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            if (!ApplicationAPIs.ApplicationStart())
                this.Shutdown();
        }

        void App_Exit(object sender, ExitEventArgs e)
        {
            ApplicationAPIs.ApplicationExit();
        }
    }
}
