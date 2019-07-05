using IdentityServer4.Models;
using IdentityServer4.Stores;
using PawPos.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Repository.Identity
{
    public interface IClientRepository : IRepository<IdentityClient>, IClientStore
    {        
    }
}
