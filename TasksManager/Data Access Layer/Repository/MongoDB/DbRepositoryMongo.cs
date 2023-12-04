using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.EF;

namespace Data_Access_Layer.Repository.MongoDB
{
    public class DbRepositoryMongo : IDbRepository
    {
        TaskDBMongo db;
        TaskRepositoryMongo taskRepository;
        TaskKindRepositoryMongo taskKindRepository;
        TaskStatusRepositoryMongo taskStatusRepository;
        ReportRepositoryMongo reportRepository;

        public DbRepositoryMongo(string cs)
        {
            db = new TaskDBMongo(cs);
            taskRepository = new TaskRepositoryMongo(db);
            taskKindRepository = new TaskKindRepositoryMongo(db);
            taskStatusRepository = new TaskStatusRepositoryMongo(db);
            reportRepository = new ReportRepositoryMongo(db);
        }

        public IRepository<Task> Tasks
        {
            get { return taskRepository; }
        }

        public IRepository<TaskKind> TaskKinds
        {
            get { return taskKindRepository;  }
        }

        public IRepository<TaskStatus> TaskStatuses
        {
            get { return taskStatusRepository; }
        }

        public IReportsRepository Reports
        {
            get { return reportRepository; }
        }

        public int Save()
        {
            return 1;
        }
    }
}
