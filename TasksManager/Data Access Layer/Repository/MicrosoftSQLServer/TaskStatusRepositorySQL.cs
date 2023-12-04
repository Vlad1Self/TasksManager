using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data.Entity;
using Data_Access_Layer.EF;
using Data_Access_Layer.Interfaces;

namespace Data_Access_Layer.Repository.MicrosoftSQLServer
{
    class TaskStatusRepositorySQL : IRepository<TaskStatus>
    {
        private TaskDBMsSQL db;

        public TaskStatusRepositorySQL(TaskDBMsSQL db)
        {
            this.db = db;
        }

        public List<TaskStatus> GetList()
        {
            return db.TaskStatuses.ToList();
        }

        public TaskStatus GetItem(int id)
        {
            return db.TaskStatuses.Find(id);
        }

        public void Create(TaskStatus taskStatus)
        {
            db.TaskStatuses.Add(taskStatus);
        }

        public void Update(TaskStatus taskStatus)
        {
            db.Entry(taskStatus).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TaskStatus taskStatus = db.TaskStatuses.Find(id);
            if (taskStatus != null) db.TaskStatuses.Remove(taskStatus);
        }
    }
}
