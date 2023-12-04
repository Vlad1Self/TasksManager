using Business_Logic_Layer;
using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2EF.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbCrud>().To<DbDataOperation>();
            Bind<IReportsService>().To<ReportsService>();
            Bind<ITaskService>().To<TaskService>();
        }
    }
}
