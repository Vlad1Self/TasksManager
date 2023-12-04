using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Repository.MicrosoftSQLServer;
using Data_Access_Layer.Repository.MongoDB;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Util
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connectionSrting_par)
        {
            connectionString = connectionSrting_par;
        }

        public override void Load()
        {
            Bind<IDbRepository> ().To<DbRepositorySQL>().InSingletonScope().WithConstructorArgument(connectionString);
            //Bind<IDbRepository> ().To<DbRepositoryMongo>().InSingletonScope().WithConstructorArgument(connectionString);
        }
    }
}
