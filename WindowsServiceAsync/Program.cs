using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WindowsServiceAsync.Data;

namespace WindowsServiceAsync
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main()
        {
            /*
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
            */
            
            Console.WriteLine("Login SAP - Service Layer ...");
            ItemData itemData = new ItemData();
            string token = itemData.Login();
            Service.Information.getData(token);
            Console.Read();

            

        }
    }
}
