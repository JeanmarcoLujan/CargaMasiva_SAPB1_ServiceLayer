using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WindowsServiceAsync.Service;

namespace WindowsServiceAsync
{
    public partial class Service1 : ServiceBase
    {

        //Timer timer = new Timer();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WriteToFile("Servicio para la migracion de entregas se ha iniciado " + DateTime.Now);
            //timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            /*
            timer.Elapsed += OnElapsedTime;
            timer.Interval = 20000;
            timer.Enabled = true;

            */
            /*
            Timer t = new Timer(20000);
            t.AutoReset = true;
            t.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            t.Start();
            */

            //Timer timer = new Timer(1000);
            //timer.Elapsed += async (sender, e) => await new ElapsedEventHandler(OnElapsedTime).get;


        }

        protected override void OnStop()
        {
            WriteToFile("Servicio para la migracion de entregas se ha detenido " + DateTime.Now);
        }

        private async void OnElapsedTime(object source, ElapsedEventArgs e)
        {

           // await Information.getData();


            WriteToFile(DateTime.Now + "Se termino");
        }


        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}
