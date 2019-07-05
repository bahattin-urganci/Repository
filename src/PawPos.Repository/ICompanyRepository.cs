using PawPos.Domain;
using PawPos.Domain.Company;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Repository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<IEnumerable<Company>> GetChildCompanies(string parentCompanyId);
    }
}
