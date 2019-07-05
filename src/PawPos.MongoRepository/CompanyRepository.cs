using Microsoft.Extensions.Options;
using PawPos.Domain;
using PawPos.Domain.Company;
using PawPos.Infrastructure;
using PawPos.Infrastructure.Attributes;
using PawPos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.MongoRepository
{
    [Transient]
    public class CompanyRepository : MongoRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(IOptions<MongoDbSettings> options) : base(options) { }

        public async Task<IEnumerable<Company>> GetChildCompanies(string parentCompanyId) => await FindAsync(x => x.ParentId == parentCompanyId);
    }
}
