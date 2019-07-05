using PawPos.Domain;
using PawPos.Infrastructure.Attributes;
using PawPos.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.MongoRepository.Tenants
{
    [Transient]
    public class AssetRepository : MongoRepository<Asset>, IAssetRepository
    {
        public AssetRepository(IDatabaseFinder databaseFinder)
        {
            SetConnection(databaseFinder.GetDbSettings());
        }

        public Task<IEnumerable<Asset>> GetTables() => FindAsync(x => x.AssetType == Model.Types.AssetType.Table);
    }
}
