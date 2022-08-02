using System.Collections.Generic;

namespace Trivia.Infrastructure.Application.Database.LevelDatabase.Data
{
    public class LevelDataModel
    {
        public int LevelNumber { get; }
        public int MapTemplateIndex { get; }
        public List<QuizQuestionDataModel> LevelQuestionList { get; }

        public LevelDataModel(int levelNumber, int mapTemplateIndex, List<QuizQuestionDataModel> levelQuestionList)
        {
            LevelNumber = levelNumber;
            MapTemplateIndex = mapTemplateIndex;
            LevelQuestionList = levelQuestionList;
        }
    }
}