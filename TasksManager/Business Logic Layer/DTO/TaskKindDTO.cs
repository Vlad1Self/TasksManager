using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;

namespace Business_Logic_Layer.DTO
{
    public class TaskKindDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Color { get; set; }

        public TaskKindDTO() { }

        public TaskKindDTO(Data_Access_Layer.EF.TaskKind tk)
        {
            Id = tk.Id;
            Name = tk.Name;
            Color = (int)tk.Color;
        }
    }
}
