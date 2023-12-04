using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_Access_Layer.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using Data_Access_Layer.EF;

namespace Data_Access_Layer.Repository.MongoDB
{
    public class ReportRepositoryMongo : IReportsRepository
    {
        TaskDBMongo db;

        public ReportRepositoryMongo(TaskDBMongo db)
        {
            this.db = db;
        }

        public List<EF.ReportSelectionByKind_Entity> ReportSelectionByKind(int SelectedIndex)
        {
            return (
                from t in db.TaskCollection.AsQueryable()
                //join k in db.KindCollection.AsQueryable()
                //join s in db.StatusCollection.AsQueryable()
                //on t.KindId equals k.Id into gr
                where t.KindId == SelectedIndex
                select new ReportSelectionByKind_Entity()
                {
                    Name = t.Name,
                    Description = t.Description,
                    StatusId = t.StatusId,
                    BeginDate = t.BeginDate,
                    BeginTime = t.BeginTime,
                    EndDate = t.EndDate,
                    EndTime = t.EndTime,
                    IsRepeat = t.IsRepeat,
                    RepeatIntervalDays = t.RepeatIntervalDays,
                    RepeatIntervalWeeks = t.RepeatIntervalWeeks,
                    RepeatIntervalMonths = t.RepeatIntervalMonths,
                    RepeatIntervalYears = t.RepeatIntervalYears,
                }
                )
                .ToList();
        }

        public List<ReportSelectionByStatus_Entity> ReportSelectionByStatus(int SelectedIndex)
        {
            return (
                from t in db.TaskCollection.AsQueryable()
                where t.StatusId == SelectedIndex
                select new ReportSelectionByStatus_Entity()
                {
                    Name = t.Name,
                    Description = t.Description,
                    KindId = t.KindId,
                    BeginDate = t.BeginDate,
                    BeginTime = t.BeginTime,
                    EndDate = t.EndDate,
                    EndTime = t.EndTime,
                    IsRepeat = t.IsRepeat,
                    RepeatIntervalDays = t.RepeatIntervalDays,
                    RepeatIntervalWeeks = t.RepeatIntervalWeeks,
                    RepeatIntervalMonths = t.RepeatIntervalMonths,
                    RepeatIntervalYears = t.RepeatIntervalYears,
                }
                )
                .ToList();
        }

        public List<ReportSelectionByRepeatability_Entity> ReportSelectionByRepeatability(bool isRepeat)
        {
            return (
                from t in db.TaskCollection.AsQueryable()
                where t.IsRepeat == isRepeat
                select new ReportSelectionByRepeatability_Entity()
                {
                    Name = t.Name,
                    Description = t.Description,
                    KindId = t.KindId,
                    StatusId = t.StatusId,
                    BeginDate = t.BeginDate,
                    BeginTime = t.BeginTime,
                    EndDate = t.EndDate,
                    EndTime = t.EndTime,
                    RepeatIntervalDays = t.RepeatIntervalDays,
                    RepeatIntervalWeeks = t.RepeatIntervalWeeks,
                    RepeatIntervalMonths = t.RepeatIntervalMonths,
                    RepeatIntervalYears = t.RepeatIntervalYears,
                }
                )
                .ToList();
        }
    }
}