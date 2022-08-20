using Trivia.Infrastructure.Application.Database.LevelDatabase.Service;
using Trivia.Infrastructure.Application.Database.RunTime;
using Trivia.Infrastructure.Core.Builders.LevelCategories;
using Trivia.Infrastructure.Core.Builders.LevelMap;
using Trivia.Infrastructure.Core.Data.RunTimeData;

namespace Trivia.Infrastructure.Core.Systems
{
    public class LevelSetUpSystem
    {
        private readonly ApplicationRunTimeData _applicationRunTimeData = null;
        private readonly LevelDatabaseService _levelDatabaseService;
        private readonly LevelRunTimeData _levelRunTimeData;
        private readonly LevelMapBuilder _levelMapBuilder;
        private readonly LevelCategoriesBuilder _levelCategoriesBuilder = null;

        public LevelSetUpSystem(ApplicationRunTimeData applicationRunTimeData,
            LevelDatabaseService levelDatabaseService,
            LevelRunTimeData levelRunTimeData,
            LevelMapBuilder levelMapBuilder,
            LevelCategoriesBuilder levelCategoriesBuilder)
        {
            _applicationRunTimeData = applicationRunTimeData;
            _levelDatabaseService = levelDatabaseService;
            _levelRunTimeData = levelRunTimeData;
            _levelMapBuilder = levelMapBuilder;
            _levelCategoriesBuilder = levelCategoriesBuilder;
        }
        
        public void ConfigureLevel()
        {
            var currentLevelNumber = _applicationRunTimeData.CurrentLevelNumber;
            var tempLevelData = _levelDatabaseService.GetLevelDataModel(currentLevelNumber);
            _levelRunTimeData.CurrentLevelDataModel = tempLevelData;
        }

        public void SetUpLevel()
        {
            _levelMapBuilder.Build();
            _levelCategoriesBuilder.Build();
        }
    }
}