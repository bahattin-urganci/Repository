using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Repository.Identity
{
    public interface IIdentityResourceRepository : IRepository<PawPos.Domain.Identity.Resource>
    {        
        
    }
}
