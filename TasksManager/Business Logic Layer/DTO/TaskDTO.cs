using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;

namespace Business_Logic_Layer.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string/*?*/ Name { get; set; }
        public string/*?*/ Description { get; set; }
        public int? KindId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? BeginDate { get; set; }
        public TimeSpan? BeginTime { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool IsRepeat { get; set; }
        public int? RepeatIntervalDays { get; set; }
        public int? RepeatIntervalWeeks { get; set; }
        public int? RepeatIntervalMonths { get; set; }
        public int? RepeatIntervalYears { get; set; }

        public TaskDTO() { }

        public TaskDTO(Data_Access_Layer.EF.Task t)
        {
            Id = t.Id;
            Name = t.Name;
            Description = t.Description;
            KindId = t.KindId;
            StatusId = t.StatusId;
            BeginDate = t.BeginDate;
            BeginTime = t.BeginTime;
            EndDate = t.EndDate;
            EndTime = t.EndTime;
            IsRepeat = t.IsRepeat;
            RepeatIntervalDays = t.RepeatIntervalDays;
            RepeatIntervalWeeks = t.RepeatIntervalWeeks;
            RepeatIntervalMonths = t.RepeatIntervalMonths;
            RepeatIntervalYears = t.RepeatIntervalYears;
        }
    }
}
