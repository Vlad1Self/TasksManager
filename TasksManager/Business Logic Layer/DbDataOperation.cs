using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data_Access_Layer;
using Data_Access_Layer.EF;
using Data_Access_Layer.Interfaces;
using Business_Logic_Layer.DTO;
using Business_Logic_Layer.Interfaces;

namespace Business_Logic_Layer
{
    // CRUD (Create, Read, Update, Delete)
    public class DbDataOperation : IDbCrud
    {
        //public TaskContext db;
        IDbRepository db;

        public DbDataOperation(IDbRepository repos)
        {
            db = repos;
            //db.Tasks.Load();
            //db.TaskKinds.Load();
            //db.TaskStatuses.Load();
        }

        // Create

        public void CreateTask(TaskDTO t)
        {
            db.Tasks.Create(new Data_Access_Layer.EF.Task()
            {
                Name = t.Name,
                Description = t.Description,
                StatusId = t.StatusId,
                KindId = t.KindId,
                BeginDate = t.BeginDate,
                BeginTime = t.BeginTime,
                EndDate = t.EndDate,
                EndTime = t.EndTime,
                IsRepeat = t.IsRepeat,
                RepeatIntervalDays = t.RepeatIntervalDays,
                RepeatIntervalMonths = t.RepeatIntervalMonths,
                RepeatIntervalWeeks = t.RepeatIntervalWeeks,
                RepeatIntervalYears = t.RepeatIntervalYears,
            });
            Save();
        }

        public void CreateKind(TaskKindDTO tk)
        {
            db.TaskKinds.Create(new Data_Access_Layer.EF.TaskKind()
            {
                Name = tk.Name,
                Color = tk.Color,
            });
            Save();
        }

        public void CreateStatus(TaskStatusDTO ts)
        {
            db.TaskStatuses.Create(new Data_Access_Layer.EF.TaskStatus()
            {
                Name = ts.Name,
                Color = ts.Color,
            });
            Save();
        }

        // Read

        public TaskDTO GetTask(int id)
        {
            return new TaskDTO(db.Tasks.GetItem(id));
        }

        public List<TaskDTO> GetAllTasks()
        {
            return db.Tasks.GetList().Select(i => new TaskDTO(i)).ToList();
        }

        public TaskKindDTO GetTaskKind(int id)
        {
            return new TaskKindDTO(db.TaskKinds.GetItem(id));
        }

        public List<TaskKindDTO> GetAllTaskKinds()
        {
            return db.TaskKinds.GetList().Select(i => new TaskKindDTO(i)).ToList();
        }

        public List<TaskKindDTO> GetAllTaskKindsForCombobox()
        {
            List<TaskKindDTO>  allTaskKinds = db.TaskKinds.GetList().Select(i => new TaskKindDTO(i)).ToList();
            allTaskKinds.Insert(0, new TaskKindDTO()); // добавление возможности выбрать вариант NULL
            return allTaskKinds;
        }

        public TaskStatusDTO GetTaskStatus(int id)
        {
            return new TaskStatusDTO(db.TaskStatuses.GetItem(id));
        }

        public List<TaskStatusDTO> GetAllTaskStatuses()
        {
            return db.TaskStatuses.GetList().Select(i => new TaskStatusDTO(i)).ToList();
        }

        public List<TaskStatusDTO> GetAllTaskStatusesForCombobox()
        {
            List<TaskStatusDTO> allTaskStatuses = db.TaskStatuses.GetList().Select(i => new TaskStatusDTO(i)).ToList();
            allTaskStatuses.Insert(0, new TaskStatusDTO()); // добавление возможности выбрать вариант NULL
            return allTaskStatuses;
        }

        // Update

        public void UpdateTask(TaskDTO t_new)
        {
            Data_Access_Layer.EF.Task task = db.Tasks.GetItem(t_new.Id);
            task.Name = t_new.Name;
            task.Description = t_new.Description;
            task.StatusId = t_new.StatusId;
            task.KindId = t_new.KindId;
            task.BeginDate = t_new.BeginDate;
            task.BeginTime = t_new.BeginTime;
            task.EndDate = t_new.EndDate;
            task.EndTime = t_new.EndTime;
            task.IsRepeat = t_new.IsRepeat;
            task.RepeatIntervalDays = t_new.RepeatIntervalDays;
            task.RepeatIntervalWeeks = t_new.RepeatIntervalWeeks;
            task.RepeatIntervalMonths = t_new.RepeatIntervalMonths;
            task.RepeatIntervalYears = t_new.RepeatIntervalYears;
            db.Tasks.Update(task);
            Save();
        }

        public void UpdateTaskKind(TaskKindDTO tk_new)
        {
            Data_Access_Layer.EF.TaskKind taskKind = db.TaskKinds.GetItem(tk_new.Id);
            taskKind.Name = tk_new.Name;
            taskKind.Color = tk_new.Color;
            db.TaskKinds.Update(taskKind);
            Save();
        }

        public void UpdateTaskStatus(TaskStatusDTO ts_new)
        {
            Data_Access_Layer.EF.TaskStatus taskStatus = db.TaskStatuses.GetItem(ts_new.Id);
            taskStatus.Name = ts_new.Name;
            taskStatus.Color = ts_new.Color;
            db.TaskStatuses.Update(taskStatus);
            Save();
        }


        // Delete

        public void DeleteTask(int id)
        {
            Data_Access_Layer.EF.Task t = db.Tasks.GetItem(id);
            if (t != null)
            {
                db.Tasks.Delete(t.Id);
                Save();
            }
        }

        public void DeleteTaskKind(int id)
        {
            Data_Access_Layer.EF.TaskKind tk = db.TaskKinds.GetItem(id);
            if (tk != null)
            {
                db.TaskKinds.Delete(tk.Id);
                Save();
            }
        }

        public void DeleteTaskStatus(int id)
        {
            Data_Access_Layer.EF.TaskStatus ts = db.TaskStatuses.GetItem(id);
            if (ts != null)
            {
                db.TaskStatuses.Delete(ts.Id);
                Save();
            }
        }


        // Сохранение базы данных
        public void Save()
        {
            db.Save();
        }
    }
}
