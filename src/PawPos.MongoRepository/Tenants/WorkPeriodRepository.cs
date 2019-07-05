using PawPos.Domain;
using PawPos.Infrastructure.Attributes;
using PawPos.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.MongoRepository.Tenants
{
    [Transient]
    public class WorkPeriodRepository :MongoRepository<WorkPeriod>,IWorkPeriodRepository
    {
        public WorkPeriodRepository(IDatabaseFinder databaseFinder) => SetConnection(databaseFinder.GetDbSettings());

        public Task<WorkPeriod> OpenPeriod() => GetAsync(x => x.Start != null && x.End == null);
    }
}
