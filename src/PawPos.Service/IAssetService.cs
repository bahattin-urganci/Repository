using PawPos.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Service
{
    public interface IAssetService :IBaseService<AssetDTO>
    {
        Task<List<AssetDTO>> GetTables();
    }
}
