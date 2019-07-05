using PawPos.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.MongoRepository
{
    public class MongoDbSettings : IDbSettings
    {


        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
