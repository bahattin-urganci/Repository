using PawPos.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.MongoRepository
{
    public static class Cache
    {
        public static Dictionary<string,IDbSettings> CompanyDbSettings { get; set; }
    }
}
