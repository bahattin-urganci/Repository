using PawPos.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using static PawPos.Model.Types;

namespace PawPos.Domain
{
    [WillBeMap("Asset")]
    public class Asset :BaseEntity
    {
        public string Name { get; set; }
        public AssetType  AssetType { get; set; }

    }
}
