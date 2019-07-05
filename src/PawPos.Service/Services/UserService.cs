using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using PawPos.Infrastructure;
using PawPos.Infrastructure.Attributes;
using PawPos.Model;
using PawPos.Model.User;
using PawPos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Service.Services.Identity
{
    [Transient]
    public class UserService : BaseService, IUserService
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        public UserService(IPasswordService passwordService, IUserRepository userRepository, ICompanyRepository companyRepository)
        {
            _passwordService = passwordService;
            _userRepository = userRepository;
            _companyRepository = companyRepository;
        }
        public async Task<ActionResponse<UserDTO>> AddUser(UserDTO user)
        {
            user.Password = _passwordService.HashPassword(user.Password);
            user.Roles.Add("app");
            user.Roles.Add(user.Role);
            await _userRepository.AddAsync(Map<Domain.User>(user));
            ActionResponse<UserDTO> response = new ActionResponse<UserDTO> { Response = user };
            return response;
        }

        public async Task<ActionResponse<UserDTO>> UpdateUserAsync(UserDTO user)
        {
            var response = CreateResponse(user);
            var data = await _userRepository.SingleOrDefaultAsync(x => x.Id == user.Id);
            user.Password = data.Password;
            if (user.Roles.Count == 1)
            {
                user.Roles.Add(user.Role);
            }
            else
            {
                user.Roles[1] = user.Role;
            }
            await _userRepository.UpdateAsync(Map<Domain.User>(user));
            return response;
        }

        public async Task ChangePassword(ChangePasswordDTO changePasswordDTO)
        {

            var user = await _userRepository.GetUserById(changePasswordDTO.UserId);
            user.Password = _passwordService.HashPassword(changePasswordDTO.NewPassword);
            await _userRepository.SaveAsync(user);

        }

        public async Task<UserDTO> GetUser(string userId)
        {
            var user = await _userRepository.SingleOrDefaultAsync(x => x.Id == userId);            

            return Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> GetUsersOfGroup(string groupId)
        {
            var usersOfGroup = (await _userRepository.FindAsync(x => x.GroupId == groupId)).ToList();

            return Map<List<UserDTO>>(usersOfGroup);

        }

        public async Task<ActionResponse<AuthenticationDTO>> Login(string userName, string password)
        {
            ActionResponse<AuthenticationDTO> response = new ActionResponse<AuthenticationDTO>() { Response = new AuthenticationDTO() };

            var user = await _userRepository.SingleOrDefaultAsync(x => x.UserName == userName && x.Status);
            if (user == null)
            {
                response.ResponseType = Types.Response.Warning;
                response.Message = "User not found";
                return response;
            }
            var verificationResult = _passwordService.VerifyHashedPassword(user.Password, password);
            switch (verificationResult)
            {
                case Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed:
                    response.ResponseType = Types.Response.Warning;
                    response.Message = "User not found";
                    return response;

                case Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success:
                    response.Response.User = new UserDTO { UserName = userName, Roles = user.Roles, AuthorizedCompanies = user.AuthorizedCompanies, Status = user.Status, Id = user.Id };
                    if (string.IsNullOrEmpty(user.ActiveCompanyId))
                    {
                        response.Response.User.ActiveCompanyId = user.AuthorizedCompanies[0];
                        response.Response.User.ActiveCompany = (await _companyRepository.SingleOrDefaultAsync(x => x.Id == response.Response.User.ActiveCompanyId)).Name;

                    }
                    response.Response.Claims = SetClaims(response.Response.User);
                    response.Message = "User authorized";
                    response.ResponseType = Types.Response.Ok;
                    return response;
                default:
                    break;
            }
            return null;


        }

        public Task RemoveUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public List<Claim> SetClaims(UserDTO user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("userId", user.Id));
            claims.Add(new Claim("activeCompanyId", user.ActiveCompanyId));
            claims.Add(new Claim("role", string.Join(":", user.Roles)));
            claims.Add(new Claim("activeCompany", user.ActiveCompany));
            return claims;
        }

        public async Task<ActionResponse<string>> ChangeActiveCompany(ChangeActiveCompanyDTO changeActiveCompany)
        {
            var user = await _userRepository.GetUserById(changeActiveCompany.UserId);
            var response = CreateResponse(changeActiveCompany.NewActiveCompanyId);
            if (user.AuthorizedCompanies.Contains(changeActiveCompany.NewActiveCompanyId))
            {
                user.ActiveCompanyId = changeActiveCompany.NewActiveCompanyId;
                await _userRepository.SaveAsync(user);
            }
            else
            {
                response.Message = "the company is not authorized";
                response.ResponseType = Types.Response.Warning;
            }

            return response;

        }
    }
}
