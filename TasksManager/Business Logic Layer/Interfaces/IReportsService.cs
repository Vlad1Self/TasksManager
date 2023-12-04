using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Business_Logic_Layer.DTO.ReportDTOs;

namespace Business_Logic_Layer.Interfaces
{
    public interface IReportsService
    {
        List<SelectionByKindDTO> ReportSelectionByKind(int SelectedIndex);
        List<SelectionByStatusDTO> ReportSelectionByStatus(int SelectedIndex);
        List<SelectionByRepeatabilityDTO> ReportSelectionByRepeatability(bool isRepeat);
    }
}
