using Business_Logic_Layer;
using Business_Logic_Layer.Util;
using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Services;
using Lab2EF.Util;
using Ninject;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2EF
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connection = ConfigurationManager.ConnectionStrings["TaskContext"].ConnectionString;
            //string connection = ConfigurationManager.ConnectionStrings["TaskContextMongoDb"].ConnectionString;
            // внедрение зависимостей
            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule(connection));

            IDbCrud crudServ = kernel.Get<IDbCrud>();
            IReportsService reportsServ = kernel.Get<IReportsService>();
            ITaskService taskServ = kernel.Get<ITaskService>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(crudServ, reportsServ, taskServ));
        }
    }
}