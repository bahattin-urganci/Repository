using PawPos.Infrastructure.Attributes;
using PawPos.Model;
using PawPos.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Service.Services.Tenants
{
    [Transient]
    public class AssetService : BaseService, IAssetService
    {
        private IAssetRepository _assetRepository;
        public AssetService(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }
        public async Task<List<AssetDTO>> AllAsync() => Map<List<AssetDTO>>(await _assetRepository.GetAllAsync());

        public async Task<AssetDTO> FindOneAsync(string id) => Map<AssetDTO>(await _assetRepository.GetAsync(x => x.Id == id));

        public async Task<List<AssetDTO>> GetTables()
        {
            return Map<List<AssetDTO>>(await _assetRepository.GetTables());
        }

        public Task RemoveAsync(AssetDTO data) => _assetRepository.RemoveAsync(Map<Domain.Asset>(data));

        public async Task<ActionResponse<AssetDTO>> SaveAsync(AssetDTO data)
        {
            data.AssetType = Types.AssetType.Table;
            var response = CreateResponse(data);
            response.Response.Id = await _assetRepository.SaveAsync(Map<Domain.Asset>(data));
            return response;
        }
    }
}
