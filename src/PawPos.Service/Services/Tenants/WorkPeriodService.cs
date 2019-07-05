using PawPos.Infrastructure.Attributes;
using PawPos.Model;
using PawPos.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Service.Services.Tenants
{
    [Scoped]
    public class WorkPeriodService : BaseService, IWorkPeriodService
    {
        IWorkPeriodRepository _workPeriodRepository;
        public WorkPeriodService(IWorkPeriodRepository workPeriodRepository)
        {
            _workPeriodRepository = workPeriodRepository;
        }
        public async Task<ActionResponse<WorkPeriodDTO>> BeginWorkPeriod(WorkPeriodDTO workPeriodDTO)
        {
            var response = CreateResponse<WorkPeriodDTO>();
            var openPeriod = await _workPeriodRepository.OpenPeriod();
            if (openPeriod == null)
            {
                await _workPeriodRepository.SaveAsync(new Domain.WorkPeriod { Start = DateTime.Now, StartDescription = workPeriodDTO?.StartDescription });
            }
            else
            {
                response.ResponseType = Types.Response.Warning;
                response.Message = "There is already an open period";
            }

            return response;

        }

        public async Task<ActionResponse<WorkPeriodDTO>> EndWorkPeriod(WorkPeriodDTO workPeriodDTO)
        {
            var response = CreateResponse(workPeriodDTO);
            var openPeriod = await _workPeriodRepository.OpenPeriod();
            if (openPeriod != null)
            {
                openPeriod.End = DateTime.Now;
                openPeriod.EndDescription = workPeriodDTO?.EndDescription;
                await _workPeriodRepository.SaveAsync(openPeriod);
            }
            else
            {
                response.ResponseType = Types.Response.Warning;
                response.Message = "There is no open period";
            }

            return response;
        }

        public async Task<WorkPeriodDTO> GetOpenPeriod()
        {
            var openPeriod = await _workPeriodRepository.OpenPeriod();
            return Map<WorkPeriodDTO>(openPeriod);
        }
    }
}
