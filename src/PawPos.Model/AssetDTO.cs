using PawPos.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using static PawPos.Model.Types;

namespace PawPos.Model
{
    [WillBeMap("Asset")]
    public class AssetDTO : BaseDTO
    {
        public string Name { get; set; }
        public AssetType AssetType { get; set; }
    }
}
