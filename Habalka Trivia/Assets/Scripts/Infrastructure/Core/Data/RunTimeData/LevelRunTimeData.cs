using System.Collections.Generic;
using Trivia.Infrastructure.Application.Database.LevelDatabase.Data;
using Trivia.Infrastructure.Core.MonoModels.Level;
using Trivia.Infrastructure.Core.MonoModels.MapCell;

namespace Trivia.Infrastructure.Core.Data.RunTimeData
{
    public class LevelRunTimeData
    {
        public LevelDataModel CurrentLevelDataModel { get; set; } = null;
        public int CurrentActiveQuestionIndex { get; set; } = 0;
        public LevelViewModel LevelViewModel { get; set; } = null;
        public List<CellCategoryViewModel> LevelCategoryCells { get; set; } = new List<CellCategoryViewModel>();
    }
}