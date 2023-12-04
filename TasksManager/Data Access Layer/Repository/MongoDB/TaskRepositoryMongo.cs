using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Data_Access_Layer.Repository.MongoDB
{
    public class TaskRepositoryMongo : IRepository<EF.Task>
    {
        private TaskDBMongo db;

        public TaskRepositoryMongo(TaskDBMongo db)
        {
            this.db = db;
        }

        public EF.Task GetItem(int id)
        {
            return db.TaskCollection.Find(i => i.Id == id).FirstOrDefault();
        }

        public List<EF.Task> GetList()
        {
            // строитель фильтров
            var builder = new FilterDefinitionBuilder<EF.Task>();
            var filter = builder.Empty; // фильтр для выборки всех документов
            return new List<EF.Task>(db.TaskCollection.Find(filter).ToList());
        }

        public void Create(EF.Task task)
        {
            EF.Task last = db.TaskCollection.Find(new FilterDefinitionBuilder<EF.Task>().Empty).SortByDescending(i => i.Id).Limit(1).FirstOrDefault();
            task.Id = last != null ? last.Id + 1 : 1;
            db.TaskCollection.InsertOneAsync(task);
        }

        public void Update(EF.Task task)
        {
            db.TaskCollection.ReplaceOneAsync(i => i.Id == task.Id, task);
            //db.TaskCollection.ReplaceOneAsync(new BsonDocument("Id", task.Id), task);
        }

        public void Delete(int id)
        {
            db.TaskCollection.DeleteOneAsync(i => i.Id == id);
        }
    }
}
