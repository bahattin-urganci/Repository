using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Repository.Identity
{
    public interface IPersistedGrantRepository :IRepository<Domain.Identity.IdentityPersistedGrant>, IPersistedGrantStore
    {
    }
}
