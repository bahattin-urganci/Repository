using PawPos.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Repository
{
    public interface IWorkPeriodRepository : IRepository<WorkPeriod>
    {
        Task<WorkPeriod> OpenPeriod();
    }
}
