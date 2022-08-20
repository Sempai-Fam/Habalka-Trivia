using System.Linq;
using Trivia.Infrastructure.Application.Configs.ResourceConfigs.MapAssets;
using Trivia.Infrastructure.Application.Factories.PrefabFactory;
using Trivia.Infrastructure.Core.Data.RunTimeData;
using Trivia.Infrastructure.Core.MonoModels.Level;

namespace Trivia.Infrastructure.Core.Builders.LevelMap
{
    public class LevelMapBuilder : ILevelBuilder
    {
        private readonly LevelRunTimeData _levelRunTimeData = null;
        private readonly CustomPrefabFactory _customPrefabFactory = null;
        private readonly LevelAssetsConfig _levelAssetsConfig = null;

        public LevelMapBuilder(LevelRunTimeData levelRunTimeData,
            CustomPrefabFactory customPrefabFactory,
            LevelAssetsConfig levelAssetsConfig)
        {
            _levelRunTimeData = levelRunTimeData;
            _customPrefabFactory = customPrefabFactory;
            _levelAssetsConfig = levelAssetsConfig;
        }

        public void Build()
        {
            BuildLevelMap();
        }

        private void BuildLevelMap()
        {
            MapAssetsConfigData currentConfig = InitializeCurrentMapConfig();
            
            LoadCurrentMap(currentConfig);
        }

        private MapAssetsConfigData InitializeCurrentMapConfig()
        {
            int currentLevelIndex = 1;
            return _levelAssetsConfig.AssetsConfigData.First(it => it.LevelIndex == currentLevelIndex);
        }

        private void LoadCurrentMap(MapAssetsConfigData currentConfigData)
        {
            _levelRunTimeData.LevelViewModel = _customPrefabFactory
                .Create<LevelViewModel>(_levelAssetsConfig.RootFolderPath, currentConfigData.AssetFileName);
        }
    }
}