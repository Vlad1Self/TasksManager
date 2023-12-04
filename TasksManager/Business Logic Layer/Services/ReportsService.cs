using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Data_Access_Layer;
using Data_Access_Layer.EF;
using Data_Access_Layer.Interfaces;
using Business_Logic_Layer.DTO;
using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.DTO.ReportDTOs;

namespace Business_Logic_Layer.Services
{
    public class ReportsService : IReportsService
    {
        private IDbRepository db;

        public ReportsService(IDbRepository repos)
        {
            db = repos;
        }

        public List<SelectionByKindDTO> ReportSelectionByKind(int SelectedIndex)
        {
            return db.Reports.ReportSelectionByKind(SelectedIndex).Select(i => new SelectionByKindDTO
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

        public List<SelectionByStatusDTO> ReportSelectionByStatus(int SelectedIndex)
        {
            return db.Reports.ReportSelectionByStatus(SelectedIndex).Select(i => new SelectionByStatusDTO
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

        public List<SelectionByRepeatabilityDTO> ReportSelectionByRepeatability(bool isRepeat)
        {
            return db.Reports.ReportSelectionByRepeatability(isRepeat).Select(i => new SelectionByRepeatabilityDTO
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

        //public static List<SelectionByKind_Data> ReportSelectionByKind(int SelectedIndex)
        //{
        //    TaskContext db = new TaskContext();
        //    return db.Tasks
        //        .Join(db.TaskKinds, t => t.KindId, st => st.Id, (t, st) => t)
        //        .Where(i => i.KindId == SelectedIndex)
        //        .Select(i => new SelectionByKind_Data
        //        {
        //            Name = i.Name,
        //            Description = i.Description,
        //            StatusId = i.StatusId,
        //            BeginDate = i.BeginDate,
        //            BeginTime = i.BeginTime,
        //            EndDate = i.EndDate,
        //            EndTime = i.EndTime,
        //            IsRepeat = i.IsRepeat,
        //            RepeatIntervalDays = i.RepeatIntervalDays,
        //            RepeatIntervalWeeks = i.RepeatIntervalWeeks,
        //            RepeatIntervalMonths = i.RepeatIntervalMonths,
        //            RepeatIntervalYears = i.RepeatIntervalYears,
        //        })
        //        .ToList();
        //}

        //public static List<SelectionByStatus_Data> ReportSelectionByStatus(int SelectedIndex)
        //{
        //    TaskContext db = new TaskContext();
        //    return db.Tasks
        //        .Join(db.TaskStatuses, t => t.StatusId, st => st.Id, (t, st) => t)
        //        .Where(i => i.StatusId == SelectedIndex)
        //        .Select(i => new SelectionByStatus_Data {
        //            Name = i.Name,
        //            Description = i.Description,
        //            KindId = i.KindId,
        //            BeginDate = i.BeginDate,
        //            BeginTime = i.BeginTime,
        //            EndDate = i.EndDate,
        //            EndTime = i.EndTime,
        //            IsRepeat = i.IsRepeat,
        //            RepeatIntervalDays = i.RepeatIntervalDays,
        //            RepeatIntervalWeeks = i.RepeatIntervalWeeks,
        //            RepeatIntervalMonths = i.RepeatIntervalMonths,
        //            RepeatIntervalYears = i.RepeatIntervalYears,
        //        })
        //        .ToList();
        //}

        //public static List<SelectionByRepeatability_Data> ReportSelectionByRepeatability(SqlParameter param)
        //{
        //    TaskContext db = new TaskContext();
        //    return db.Database
        //        .SqlQuery<SelectionByRepeatability_Data>("IsRepeatReportProcedure @isRepeat", new object[] { param })
        //        .ToList()
        //        .Select(i => new SelectionByRepeatability_Data
        //        {
        //            Name = i.Name,
        //            Description = i.Description,
        //            KindId = i.KindId,
        //            StatusId = i.StatusId,
        //            BeginDate = i.BeginDate,
        //            BeginTime = i.BeginTime,
        //            EndDate = i.EndDate,
        //            EndTime = i.EndTime,
        //            RepeatIntervalDays = i.RepeatIntervalDays,
        //            RepeatIntervalWeeks = i.RepeatIntervalWeeks,
        //            RepeatIntervalMonths = i.RepeatIntervalMonths,
        //            RepeatIntervalYears = i.RepeatIntervalYears,
        //        })
        //        .ToList();
        //}
    }
}
