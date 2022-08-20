using Trivia.Infrastructure.Application.Database.LevelDatabase.Data;
using Trivia.Infrastructure.Core.Data.RunTimeData;
using Trivia.Infrastructure.Core.MonoModels.Level;
using Trivia.Infrastructure.Core.MonoModels.MapCell;
using UnityEngine.EventSystems;

namespace Trivia.Infrastructure.Core.Builders.LevelCategories
{
    public class LevelCategoriesBuilder : ILevelBuilder
    {
        private readonly CellCategoryViewModel.Factory _cellCategoryFactory = null;
        private readonly LevelRunTimeData _levelRunTimeData = null;

        public LevelCategoriesBuilder(CellCategoryViewModel.Factory cellCategoryFactory, LevelRunTimeData levelRunTimeData)
        {
            _cellCategoryFactory = cellCategoryFactory;
            _levelRunTimeData = levelRunTimeData;
        }
        
        public void Build()
        {
            BuildCurrentCells();
        }

        private void BuildCurrentCells()
        {
            var tempLevel = _levelRunTimeData.LevelViewModel;

            for (int index = 0; index < tempLevel.LevelElements.Count; index++)
            {
                LevelElementViewModel currentViewElement = tempLevel.LevelElements[index];
                
                CellCategoryViewModel tempCell = _cellCategoryFactory.Create(currentViewElement.transform.position);
                tempCell.Initialize(index, currentViewElement);
                
                InitializeCell(tempCell, null);
                
                _levelRunTimeData.LevelCategoryCells.Add(tempCell);
            }
        }

        private void InitializeCell(CellCategoryViewModel cellCategoryViewModel, QuizQuestionDataModel questionModel)
        {
            EventTrigger.Entry onCellClick = new EventTrigger.Entry();
            onCellClick.eventID = EventTriggerType.PointerClick;
            onCellClick.callback.AddListener((_) => { OnMapCellButtonClick(cellCategoryViewModel.CellIndex); });
            cellCategoryViewModel.CellEventTrigger.triggers.Add(onCellClick);
        }

        private void OnMapCellButtonClick(int cellIndex)
        {
            
        }
    }
}