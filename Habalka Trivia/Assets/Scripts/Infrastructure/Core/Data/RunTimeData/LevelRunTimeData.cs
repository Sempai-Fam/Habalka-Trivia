using Trivia.Infrastructure.Application.Database.LevelDatabase.Data;
using Trivia.Infrastructure.Core.MonoModels.Map;

namespace Trivia.Infrastructure.Core.Data.RunTimeData
{
    public class LevelRunTimeData
    {
        public LevelDataModel CurrentLevelDataModel { get; set; } = null;
        public int CurrentActiveQuestionIndex { get; set; } = 0;
        public MapViewModel MapViewModel { get; set; } = null;
    }
}