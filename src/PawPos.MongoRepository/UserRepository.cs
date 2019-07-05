using Microsoft.Extensions.Options;
using PawPos.Domain;
using PawPos.Infrastructure.Attributes;
using PawPos.Infrastructure.Extension;
using PawPos.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.MongoRepository
{
    [Transient]
    public class UserRepository : MongoRepository<User>, IUserRepository
    {
        public UserRepository(IOptions<MongoDbSettings> settings) : base(settings)
        {
        }

        public Task<User> GetUser(string userName) => SingleOrDefaultAsync(x => x.UserName == userName);

        public Task<User> GetUserById(string userId) => SingleOrDefaultAsync(x => x.Id == userId);

        public Task<IEnumerable<User>> GetUsersOfGroup(string id) => FindAsync(x => x.GroupId == id);
    }
}
