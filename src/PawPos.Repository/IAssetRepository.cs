using PawPos.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Repository
{
    public interface IAssetRepository :IRepository<Asset>
    {
        Task<IEnumerable<Asset>> GetTables();
    }
}
