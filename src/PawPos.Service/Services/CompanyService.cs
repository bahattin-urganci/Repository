using PawPos.Domain.Company;
using PawPos.Infrastructure.Attributes;
using PawPos.Model;
using PawPos.Model.User;
using PawPos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Service.Services
{
    [Transient]
    public class CompanyService : BaseService, ICompanyService
    {
        ICompanyRepository _companyRepository;
        IUserRepository _userRepository;
        public CompanyService(ICompanyRepository companyRepository, IUserRepository userRepository)
        {
            _companyRepository = companyRepository;
            _userRepository = userRepository;
        }
        public async Task<ActionResponse<Company>> SaveCompany(Company company)
        {
            ActionResponse<Company> response = new ActionResponse<Company>() { ResponseType = Types.Response.Ok, Response = company };
            if (string.IsNullOrEmpty(company.Id) && _companyRepository.Exists(x => x.Name == company.Name))
            {
                response.ResponseType = Types.Response.Warning;
                response.Message = "Choose different name";
                return response;
            }

            var saved = await _companyRepository.SaveAsync(response.Response);
            response.Response = company;
            response.Response.Id = saved;
            return response;

        }


        public async Task<List<Company>> Companies(string parentCompanyId) => (await _companyRepository.GetChildCompanies(parentCompanyId)).ToList();

        public async Task<List<Company>> Groups() => (await _companyRepository.FindAsync(x => x.ParentId == null)).ToList();
        public async Task<ActionResponse<Company>> SaveGroup(Company company) => await SaveCompany(company);

        public async Task<GroupDTO> Group(string id)
        {
            var group = await _companyRepository.SingleOrDefaultAsync(x => x.Id == id);
            var companies = await Companies(group.Id);
            var users = await _userRepository.GetUsersOfGroup(id);
            return new GroupDTO
            {
                Id = group.Id,
                Name = group.Name,
                Companies = Map<List<CompanyDTO>>(companies),
                Users = Map<List<UserDTO>>(users.ToList())
            };
        }

        public async Task<Company> Company(string id) => await _companyRepository.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<List<CompanyDTO>> AuthorizedCompanies(string userId)
        {
            var user = await _userRepository.GetUserById(userId);

            var companies = await _companyRepository.FindAsync(x => user.AuthorizedCompanies.Contains(x.Id));

            return Map<List<CompanyDTO>>(companies);

        }
    }
}
