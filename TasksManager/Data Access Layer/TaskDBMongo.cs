using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;

namespace Data_Access_Layer
{
    public class TaskDBMongo
    {
        string connectionString;
        MongoClient client;
        IMongoDatabase database;

        /// <summary>
        ///  коллекция Tasks
        /// </summary>
        public IMongoCollection<EF.Task> TaskCollection
        {
            get { return database.GetCollection<EF.Task>("Task"); }
        }

        /// <summary>
        ///  коллекция Order
        /// </summary>
        public IMongoCollection<EF.TaskKind> KindCollection
        {
            get { return database.GetCollection<EF.TaskKind>("Kind"); }
        }

        /// <summary>
        ///  коллекция Order
        /// </summary>
        public IMongoCollection<EF.TaskStatus> StatusCollection
        {
            get { return database.GetCollection<EF.TaskStatus>("Status"); }
        }

        public TaskDBMongo(string cs)
        {
            connectionString = cs;
            var connection = new MongoUrlBuilder(connectionString);
            MongoClient client = new MongoClient(connectionString);
            database = client.GetDatabase(connection.DatabaseName);
        }
    }
}
