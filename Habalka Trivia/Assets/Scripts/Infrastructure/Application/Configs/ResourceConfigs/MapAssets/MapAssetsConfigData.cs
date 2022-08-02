using System;

namespace Trivia.Infrastructure.Application.Configs.ResourceConfigs.MapAssets
{
    [Serializable]
    public class MapAssetsConfigData
    {
        public string AssetFileName = string.Empty;
        public MapAssetType MapAssetType;
        public bool LoadAssetAsync = false;
    }
}