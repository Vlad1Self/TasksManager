namespace Data_Access_Layer.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Attributes;

    [Table("Task")]
    public partial class Task
    {
        //[BsonId]
        //public int _id { get; set; }

        //[DataMember]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public int? KindId { get; set; }

        public int? StatusId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BeginDate { get; set; }

        public TimeSpan? BeginTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public TimeSpan? EndTime { get; set; }

        public bool IsRepeat { get; set; }

        public int? RepeatIntervalDays { get; set; }

        public int? RepeatIntervalWeeks { get; set; }

        public int? RepeatIntervalMonths { get; set; }

        public int? RepeatIntervalYears { get; set; }

        public virtual TaskStatus TaskStatus { get; set; }

        public virtual TaskKind TaskKind { get; set; }
    }
}
