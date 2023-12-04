using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_Access_Layer.Interfaces;
using MongoDB.Driver;

namespace Data_Access_Layer.Repository.MongoDB
{
    public class TaskStatusRepositoryMongo : IRepository<EF.TaskStatus>
    {
        private TaskDBMongo db;

        public TaskStatusRepositoryMongo(TaskDBMongo db)
        {
            this.db = db;
        }

        public EF.TaskStatus GetItem(int id)
        {
            return db.StatusCollection.Find(i => i.Id == id).FirstOrDefault();
        }

        public List<EF.TaskStatus> GetList()
        {
            // строитель фильтров
            var builder = new FilterDefinitionBuilder<EF.TaskStatus>();
            var filter = builder.Empty; // фильтр для выборки всех документов
            return new List<EF.TaskStatus>(db.StatusCollection.Find(filter).ToList());
        }

        public void Create(EF.TaskStatus status)
        {
            EF.TaskStatus last = db.StatusCollection.Find(new FilterDefinitionBuilder<EF.TaskStatus>().Empty).SortByDescending(i => i.Id).Limit(1).FirstOrDefault();
            status.Id = last != null ? last.Id + 1 : 1;
            db.StatusCollection.InsertOneAsync(status);
        }

        public void Update(EF.TaskStatus status)
        {
            db.StatusCollection.ReplaceOneAsync(i => i.Id == status.Id, status);
        }

        public void Delete(int id)
        {
            db.StatusCollection.DeleteOneAsync(i => i.Id == id);
        }
    }
}
