using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Repository
{
    public interface IDbSettings
    {
        string ConnectionString { get; set; }
        string Database { get; set; }
    }
}
