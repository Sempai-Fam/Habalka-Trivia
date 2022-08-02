using System.Collections.Generic;
using Trivia.Infrastructure.Application.Configs.ResourceConfigs.BaseConfig;
using UnityEngine;

namespace Trivia.Infrastructure.Application.Configs.ResourceConfigs.MapAssets
{
    [CreateAssetMenu(menuName = "Configs/Assets/Map Configs", fileName = "Map_Asset_Config")]
    public class MapAssetsConfig : BaseResourceConfig
    {
        [SerializeField] private List<MapAssetsConfigData> _assetsConfigData = new List<MapAssetsConfigData>();

        public IEnumerable<MapAssetsConfigData> AssetsConfigData => _assetsConfigData;
    }
}