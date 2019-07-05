
//using PawPos.Auth;
using PawPos.Infrastructure.Attributes;
using PawPos.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.MongoRepository
{
    [Transient]
    public class DatabaseFinder : IDatabaseFinder
    {

        //*****************ÖRNEK AMACIYLA KAPALI***************************

        //private IAuthorizationService _authorizationService;
        //public DatabaseFinder(IAuthorizationService authorizationService)
        //{
        //    _authorizationService = authorizationService;
        //}
        //public IDbSettings GetDbSettings() => Cache.CompanyDbSettings[_authorizationService.GetClaim("activeCompanyId")];
        public IDbSettings GetDbSettings()
        {
            throw new NotImplementedException();
        }
    }
}
