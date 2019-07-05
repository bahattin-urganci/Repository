using PawPos.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Repository
{
    public interface IUserRepository :IRepository<User>
    {
        Task<User> GetUserById(string userId);
        Task<User> GetUser(string userName);        
        Task<IEnumerable<User>> GetUsersOfGroup(string id);
    }
}
