using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;

namespace Business_Logic_Layer.DTO
{
    public class TaskStatusDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Color { get; set; }

        public TaskStatusDTO() { }

        public TaskStatusDTO(Data_Access_Layer.EF.TaskStatus ts)
        {
            Id = ts.Id;
            Name = ts.Name;
            Color = (int)ts.Color;
        }
    }
}
