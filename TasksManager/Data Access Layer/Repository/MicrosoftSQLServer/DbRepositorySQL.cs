using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Data_Access_Layer.EF;
using Data_Access_Layer.Interfaces;

namespace Data_Access_Layer.Repository.MicrosoftSQLServer
{
    public class DbRepositorySQL : IDbRepository
    {
        private TaskDBMsSQL db;
        private TaskRepositorySQL taskRepositorySQL;
        private TaskKindRepositorySQL taskKindRepositorySQL;
        private TaskStatusRepositorySQL taskStatusRepositorySQL;
        private ReportRepositorySQL reportRepositorySQL;

        public DbRepositorySQL(TaskDBMsSQL db)
        {
            this.db = db;
        }

        public IRepository<Task> Tasks
        {
            get
            {
                if (taskRepositorySQL == null) taskRepositorySQL = new TaskRepositorySQL(db);
                return taskRepositorySQL;
            }
        }

        public IRepository<TaskKind> TaskKinds
        {
            get
            {
                if (taskKindRepositorySQL == null) taskKindRepositorySQL = new TaskKindRepositorySQL(db);
                return taskKindRepositorySQL;
            }
        }

        public IRepository<TaskStatus> TaskStatuses
        {
            get
            {
                if (taskStatusRepositorySQL == null) taskStatusRepositorySQL = new TaskStatusRepositorySQL(db);
                return taskStatusRepositorySQL;
            }
        }

        public IReportsRepository Reports
        {
            get
            {
                if (reportRepositorySQL == null)
                    reportRepositorySQL = new ReportRepositorySQL(db);
                return reportRepositorySQL;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
