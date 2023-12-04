using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.DTO.ReportDTOs
{
    public class SelectionByKindDTO
    {
        public string/*?*/ Name { get; set; }
        public string/*?*/ Description { get; set; }
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
    }

    public class SelectionByStatusDTO
    {
        public string/*?*/ Name { get; set; }
        public string/*?*/ Description { get; set; }
        public int? KindId { get; set; }
        public DateTime? BeginDate { get; set; }
        public TimeSpan? BeginTime { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool IsRepeat { get; set; }
        public int? RepeatIntervalDays { get; set; }
        public int? RepeatIntervalWeeks { get; set; }
        public int? RepeatIntervalMonths { get; set; }
        public int? RepeatIntervalYears { get; set; }
    }

    public class SelectionByRepeatabilityDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? KindId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? BeginDate { get; set; }
        public TimeSpan? BeginTime { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? RepeatIntervalDays { get; set; }
        public int? RepeatIntervalWeeks { get; set; }
        public int? RepeatIntervalMonths { get; set; }
        public int? RepeatIntervalYears { get; set; }
    }
}
