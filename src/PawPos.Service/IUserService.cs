using PawPos.Model;
using PawPos.Model.User;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Service
{
    public interface IUserService
    {
        Task<ActionResponse<UserDTO>> AddUser(UserDTO user);
        Task<ActionResponse<UserDTO>> UpdateUserAsync(UserDTO user);
        Task<ActionResponse<AuthenticationDTO>> Login(string userName, string password);
        List<Claim> SetClaims(UserDTO user);
        Task<List<UserDTO>> GetUsersOfGroup(string groupId);
        Task<UserDTO> GetUser(string userId);
        Task RemoveUser(UserDTO user);
        Task ChangePassword(ChangePasswordDTO changePasswordDTO);
        Task<ActionResponse<string>> ChangeActiveCompany(ChangeActiveCompanyDTO changeActiveCompany);

    }
}
