using System.Collections.Generic;
using Trivia.Infrastructure.Application.Database.LevelDatabase.Data;
using Zenject;

namespace Trivia.Infrastructure.Application.Database.LevelDatabase.Service
{
    public class LevelDatabaseService : IInitializable
    {
        private Dictionary<int, List<LevelDataModel>> _levelModelsBySeason = new Dictionary<int, List<LevelDataModel>>();

        public void Initialize()
        {
            BuildTestModels();
        }

        public LevelDataModel GetLevelDataModel(int levelIndex)
        {
            int currentSeasonIndex = 1;

            if (_levelModelsBySeason.ContainsKey(currentSeasonIndex))
            {
                return _levelModelsBySeason[currentSeasonIndex].Find(it => it.LevelNumber == levelIndex);
            }

            return null;
        }

        private void BuildTestModels()
        {
            int currentSeason = 1;
            var tempLevelQuestionsList = new List<QuizQuestionDataModel>();
            var tempLevelDataList = new List<LevelDataModel>();
            
            var tempQuestionModel = new QuizQuestionDataModel(
                0,
                QuizQuestionCategory.One,
                "question_1",
                "description_1",
                "image_1");
            tempLevelQuestionsList.Add(tempQuestionModel);
            tempQuestionModel = new QuizQuestionDataModel(
                1,
                QuizQuestionCategory.Two,
                "question_2",
                "description_2",
                "image_2");
            tempLevelQuestionsList.Add(tempQuestionModel);
            tempQuestionModel = new QuizQuestionDataModel(
                2,
                QuizQuestionCategory.Three,
                "question_3",
                "description_3",
                "image_3");
            tempLevelQuestionsList.Add(tempQuestionModel);
            
            
            var tempModel = new LevelDataModel(1, 0, tempLevelQuestionsList);
            tempLevelDataList.Add(tempModel);
            _levelModelsBySeason.Add(currentSeason, tempLevelDataList);
        }
    }
}