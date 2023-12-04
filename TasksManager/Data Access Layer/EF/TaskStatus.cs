namespace Data_Access_Layer.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Attributes;

    public partial class TaskStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaskStatus()
        {
            Task = new HashSet<Task>();
        }
        //[BsonId]
        //public int _id { get; set; }

        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int? Color { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Task { get; set; }
    }
}
