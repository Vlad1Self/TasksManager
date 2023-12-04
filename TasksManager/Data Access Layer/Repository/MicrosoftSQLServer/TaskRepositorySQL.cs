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
    public class TaskRepositorySQL : IRepository<Task>
    {
        private TaskDBMsSQL db;

        public TaskRepositorySQL(TaskDBMsSQL db)
        {
            this.db = db;
        }

        public List<Task> GetList()
        {
            return db.Tasks.ToList();
        }

        public Task GetItem(int id)
        {
            return db.Tasks.Find(id);
        }

        public void Create(Task task)
        {
            db.Tasks.Add(task);
        }

        public void Update(Task task)
        {
            db.Entry(task).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Task task = db.Tasks.Find(id);
            if (task != null) db.Tasks.Remove(task);
        }
    }
}
