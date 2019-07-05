using PawPos.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Service
{
    public interface IWorkPeriodService
    {
        Task<WorkPeriodDTO> GetOpenPeriod();
        Task<ActionResponse<WorkPeriodDTO>> BeginWorkPeriod(WorkPeriodDTO workPeriodDTO);
        Task<ActionResponse<WorkPeriodDTO>> EndWorkPeriod(WorkPeriodDTO workPeriodDTO);
    }
}
