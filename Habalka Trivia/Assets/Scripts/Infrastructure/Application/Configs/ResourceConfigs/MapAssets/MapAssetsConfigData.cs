using System;

namespace Trivia.Infrastructure.Application.Configs.ResourceConfigs.MapAssets
{
    [Serializable]
    public class MapAssetsConfigData
    {
        public string AssetFileName = string.Empty;
        public int LevelIndex = 0;
        public bool LoadAssetAsync = false;
    }
}