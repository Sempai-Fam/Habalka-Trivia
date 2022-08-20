using System.Collections.Generic;
using Trivia.Infrastructure.Application.Configs.ResourceConfigs.BaseConfig;
using UnityEngine;

namespace Trivia.Infrastructure.Application.Configs.ResourceConfigs.MapAssets
{
    [CreateAssetMenu(menuName = "Configs/Core/Level Configs", fileName = "Level_Asset_Config")]
    public class LevelAssetsConfig : BaseResourceConfig
    {
        [SerializeField] private List<MapAssetsConfigData> _assetsConfigData = new List<MapAssetsConfigData>();

        public IEnumerable<MapAssetsConfigData> AssetsConfigData => _assetsConfigData;
    }
}