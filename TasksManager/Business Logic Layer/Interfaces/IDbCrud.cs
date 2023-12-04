using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic_Layer.DTO;

namespace Business_Logic_Layer.Interfaces
{
    public interface IDbCrud
    {
        void CreateTask(TaskDTO t);
        void CreateKind(TaskKindDTO tk);
        void CreateStatus(TaskStatusDTO ts);
        TaskDTO GetTask(int id);
        List<TaskDTO> GetAllTasks();
        TaskKindDTO GetTaskKind(int id);
        List<TaskKindDTO> GetAllTaskKinds();
        List<TaskKindDTO> GetAllTaskKindsForCombobox();
        TaskStatusDTO GetTaskStatus(int id);
        List<TaskStatusDTO> GetAllTaskStatuses();
        List<TaskStatusDTO> GetAllTaskStatusesForCombobox();
        void UpdateTask(TaskDTO t_new);
        void UpdateTaskKind(TaskKindDTO tk_new);
        void UpdateTaskStatus(TaskStatusDTO ts_new);
        void DeleteTask(int id);
        void DeleteTaskKind(int id);
        void DeleteTaskStatus(int id);
    }
}
