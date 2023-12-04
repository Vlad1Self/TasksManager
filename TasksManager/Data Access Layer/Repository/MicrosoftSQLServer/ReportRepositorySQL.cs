using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Data_Access_Layer.EF;
using Data_Access_Layer.Interfaces;

namespace Data_Access_Layer.Repository.MicrosoftSQLServer
{
    public class ReportRepositorySQL : IReportsRepository
    {
        private TaskDBMsSQL db;

        public ReportRepositorySQL(TaskDBMsSQL db)
        {
            this.db = db;
        }

        public List<ReportSelectionByKind_Entity> ReportSelectionByKind(int SelectedIndex)
        {
            return db.Tasks
                .Join(db.TaskKinds, t => t.KindId, st => st.Id, (t, st) => t)
                .Where(i => i.KindId == SelectedIndex)
                .Select(i => new ReportSelectionByKind_Entity
                {
                    Name = i.Name,
                    Description = i.Description,
                    StatusId = i.StatusId,
                    BeginDate = i.BeginDate,
                    BeginTime = i.BeginTime,
                    EndDate = i.EndDate,
                    EndTime = i.EndTime,
                    IsRepeat = i.IsRepeat,
                    RepeatIntervalDays = i.RepeatIntervalDays,
                    RepeatIntervalWeeks = i.RepeatIntervalWeeks,
                    RepeatIntervalMonths = i.RepeatIntervalMonths,
                    RepeatIntervalYears = i.RepeatIntervalYears,
                })
                .ToList();
        }

        public List<ReportSelectionByStatus_Entity> ReportSelectionByStatus(int SelectedIndex)
        {
            return db.Tasks
                .Join(db.TaskStatuses, t => t.StatusId, st => st.Id, (t, st) => t)
                .Where(i => i.StatusId == SelectedIndex)
                .Select(i => new ReportSelectionByStatus_Entity
                {
                    Name = i.Name,
                    Description = i.Description,
                    KindId = i.KindId,
                    BeginDate = i.BeginDate,
                    BeginTime = i.BeginTime,
                    EndDate = i.EndDate,
                    EndTime = i.EndTime,
                    IsRepeat = i.IsRepeat,
                    RepeatIntervalDays = i.RepeatIntervalDays,
                    RepeatIntervalWeeks = i.RepeatIntervalWeeks,
                    RepeatIntervalMonths = i.RepeatIntervalMonths,
                    RepeatIntervalYears = i.RepeatIntervalYears,
                })
                .ToList();
        }

        // Выполнение хранимой процедуры
        public List<ReportSelectionByRepeatability_Entity> ReportSelectionByRepeatability(bool isRepeat)
        {
            //создание SqlParameter isRepeat
            SqlParameter isRepeatSqlParameter = new SqlParameter("@isRepeat", isRepeat);
            return db.Database
                .SqlQuery<ReportSelectionByRepeatability_Entity>("IsRepeatReportProcedure @isRepeat", new object[] { isRepeatSqlParameter })
                .ToList()
                .Select(i => new ReportSelectionByRepeatability_Entity
                {
                    Name = i.Name,
                    Description = i.Description,
                    KindId = i.KindId,
                    StatusId = i.StatusId,
                    BeginDate = i.BeginDate,
                    BeginTime = i.BeginTime,
                    EndDate = i.EndDate,
                    EndTime = i.EndTime,
                    RepeatIntervalDays = i.RepeatIntervalDays,
                    RepeatIntervalWeeks = i.RepeatIntervalWeeks,
                    RepeatIntervalMonths = i.RepeatIntervalMonths,
                    RepeatIntervalYears = i.RepeatIntervalYears,
                })
                .ToList();
        }
    }
}
