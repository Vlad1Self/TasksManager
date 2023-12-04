using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data_Access_Layer.EF;
using Data_Access_Layer.Interfaces;

namespace Data_Access_Layer.Repository.MicrosoftSQLServer
{
    class TaskKindRepositorySQL : IRepository<TaskKind>
    {
        private TaskDBMsSQL db;

        public TaskKindRepositorySQL(TaskDBMsSQL db)
        {
            this.db = db;
        }

        public List<TaskKind> GetList()
        {
            return db.TaskKinds.ToList();
        }

        public TaskKind GetItem(int id)
        {
            return db.TaskKinds.Find(id);
        }

        public void Create(TaskKind taskKind)
        {
            db.TaskKinds.Add(taskKind);
        }

        public void Update(TaskKind taskKind)
        {
            db.Entry(taskKind).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TaskKind taskKind = db.TaskKinds.Find(id);
            if (taskKind != null) db.TaskKinds.Remove(taskKind);
        }

    }
}
