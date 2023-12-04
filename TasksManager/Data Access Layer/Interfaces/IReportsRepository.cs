using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Data_Access_Layer.Interfaces
{
    public interface IReportsRepository
    {
        List<EF.ReportSelectionByKind_Entity> ReportSelectionByKind(int SelectedIndex);
        List<EF.ReportSelectionByStatus_Entity> ReportSelectionByStatus(int SelectedIndex);
        List<EF.ReportSelectionByRepeatability_Entity> ReportSelectionByRepeatability(bool isRepeat);
    }
}
