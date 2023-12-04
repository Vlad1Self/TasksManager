using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IDbRepository
    {
        IRepository<EF.Task> Tasks { get; }
        IRepository<EF.TaskKind> TaskKinds { get; }
        IRepository<EF.TaskStatus> TaskStatuses { get; }
        IReportsRepository Reports { get; }
        int Save();
    }
}
