using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Repository
{
    public interface IDatabaseFinder
    {
        IDbSettings GetDbSettings();
    }
}
