using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Data_Access_Layer.EF;

namespace Data_Access_Layer
{
    public partial class TaskDBMsSQL : DbContext
    {
        public TaskDBMsSQL()
            : base("name=TaskContext")
        {
        }

        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskKind> TaskKinds { get; set; }
        public virtual DbSet<TaskStatus> TaskStatuses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskKind>()
                .HasMany(e => e.Task)
                .WithOptional(e => e.TaskKind)
                .HasForeignKey(e => e.KindId);

            modelBuilder.Entity<TaskStatus>()
                .HasMany(e => e.Task)
                .WithOptional(e => e.TaskStatus)
                .HasForeignKey(e => e.StatusId);
        }
    }
}
