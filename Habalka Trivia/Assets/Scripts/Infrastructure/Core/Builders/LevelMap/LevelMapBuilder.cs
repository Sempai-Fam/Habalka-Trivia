using System.Linq;
using Trivia.Infrastructure.Application.Configs.ResourceConfigs.MapAssets;
using Trivia.Infrastructure.Application.Database.LevelDatabase.Data;
using Trivia.Infrastructure.Application.Factories.PrefabFactory;
using Trivia.Infrastructure.Core.Data.RunTimeData;
using Trivia.Infrastructure.Core.MonoModels.Map;
using Trivia.Infrastructure.Core.MonoModels.MapCell;
using UnityEngine.EventSystems;

namespace Trivia.Infrastructure.Core.Builders.LevelMap
{
    public class LevelMapBuilder : ILevelBuilder
    {
        private readonly LevelRunTimeData _levelRunTimeData;
        private readonly CustomPrefabFactory _customPrefabFactory;
        private readonly MapAssetsConfig _mapAssetsConfig;

        public LevelMapBuilder(LevelRunTimeData levelRunTimeData,
            CustomPrefabFactory customPrefabFactory,
            MapAssetsConfig mapAssetsConfig)
        {
            _levelRunTimeData = levelRunTimeData;
            _customPrefabFactory = customPrefabFactory;
            _mapAssetsConfig = mapAssetsConfig;
        }

        public void Build()
        {
            BuildLevelMap();
            
            InitializeMapCells();
        }

        private void BuildLevelMap()
        {
            MapAssetsConfigData currentConfig = InitializeCurrentMapConfig();
            
            LoadCurrentMap(currentConfig);
        }

        private MapAssetsConfigData InitializeCurrentMapConfig()
        {
            return _mapAssetsConfig.AssetsConfigData.First(it => it.MapAssetType == MapAssetType.Map1);
        }

        private void LoadCurrentMap(MapAssetsConfigData currentConfigData)
        {
            _levelRunTimeData.MapViewModel = _customPrefabFactory
                .Create<MapViewModel>(_mapAssetsConfig.RootFolderPath, currentConfigData.AssetFileName);
        }

        private void InitializeMapCells()
        {
            var tempMapModel = _levelRunTimeData.MapViewModel;

            foreach (CellCategoryViewModel cellViewModel in tempMapModel.MapCellViewModels)
            {
                var cellIndex = cellViewModel.CellIndex;
                var questionModel = _levelRunTimeData
                    .CurrentLevelDataModel
                    .LevelQuestionList.FirstOrDefault(it => it.QuestionIndex == cellIndex);
                
                InitializeCell(cellIndex, cellViewModel, questionModel);
            }
        }

        private void InitializeCell(int cellIndex, CellCategoryViewModel cellCategoryViewModel, QuizQuestionDataModel questionModel)
        {
            EventTrigger.Entry onCellClick = new EventTrigger.Entry();
            onCellClick.eventID = EventTriggerType.PointerClick;
            onCellClick.callback.AddListener((_) => { OnMapCellButtonClick(cellIndex); });
            cellCategoryViewModel.CellEventTrigger.triggers.Add(onCellClick);
        }

        private void OnMapCellButtonClick(int cellIndex)
        {
            
        }
    }
}