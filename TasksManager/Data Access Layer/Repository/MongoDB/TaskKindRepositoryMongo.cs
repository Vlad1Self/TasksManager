using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Interfaces;
using MongoDB.Driver;


namespace Data_Access_Layer.Repository.MongoDB
{
    public class TaskKindRepositoryMongo : IRepository<EF.TaskKind>
    {
        private TaskDBMongo db;

        public TaskKindRepositoryMongo(TaskDBMongo db)
        {
            this.db = db;
        }

        public EF.TaskKind GetItem(int id)
        {
            return db.KindCollection.Find(i => i.Id == id).FirstOrDefault();
        }

        public List<EF.TaskKind> GetList()
        {
            var builder = new FilterDefinitionBuilder<EF.TaskKind>();
            var filter = builder.Empty; // фильтр для выборки всех документов
            return new List<EF.TaskKind>(db.KindCollection.Find(filter).ToListAsync().Result);
            //return new List<EF.TaskKind>(db.KindCollection.Where(i => i).ToListAsync().Result);
        }

        public void Create(EF.TaskKind kind)
        {
            EF.TaskKind last = db.KindCollection.Find(new FilterDefinitionBuilder<EF.TaskKind>().Empty).SortByDescending(i => i.Id).Limit(1).FirstOrDefault();
            kind.Id = last != null ? last.Id + 1 : 1;
            db.KindCollection.InsertOneAsync(kind).Wait();
        }

        public void Update(EF.TaskKind kind)
        {
            db.KindCollection.ReplaceOneAsync(i => i.Id == kind.Id, kind);
        }

        public void Delete(int id)
        {
            db.KindCollection.DeleteOneAsync(i => i.Id == id);
        }
    }
}
