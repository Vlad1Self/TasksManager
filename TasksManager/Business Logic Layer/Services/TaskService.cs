using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic_Layer.DTO;
using Data_Access_Layer;
using Data_Access_Layer.EF;
using Data_Access_Layer.Interfaces;
using Business_Logic_Layer.Interfaces;


namespace Business_Logic_Layer.Services
{
    public class TaskService : ITaskService
    {
        private IDbRepository db;

        public TaskService(IDbRepository repos)
        {
            db = repos;
        }
    }
}
