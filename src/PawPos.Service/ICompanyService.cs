using System.Collections.Generic;
using System.Threading.Tasks;
using PawPos.Domain.Company;
using PawPos.Model;

namespace PawPos.Service
{
    public interface ICompanyService
    {
        Task<ActionResponse<Company>> SaveCompany(Company company);
        Task<List<Company>> Companies(string parentCompanyId);        
        Task<List<Company>> Groups();
        
        Task<ActionResponse<Company>> SaveGroup(Company company);
        Task<GroupDTO> Group(string id);
        Task<Company> Company(string id);
        Task<List<CompanyDTO>> AuthorizedCompanies(string userId);
    }
}