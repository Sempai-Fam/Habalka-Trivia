using System;
using Trivia.Infrastructure.Core.Data.CellCategoryType;
using Trivia.Infrastructure.Core.MonoModels.MapCell;
using UnityEngine;

namespace Trivia.Infrastructure.Core.Data.CellStatusData
{
    [Serializable] 
    public class MapCellStatusData
    {
        [SerializeField] private CellCategoryStatusType _cellCategoryStatusType = CellCategoryStatusType.None;
        [SerializeField] private Sprite _cellBackSprite = null;
        [SerializeField] private Sprite _cellFrontSprite = null;

        public CellCategoryStatusType CellCategoryStatusType => _cellCategoryStatusType;
        public Sprite CellBackSprite => _cellBackSprite;
        public Sprite CellFrontSprite => _cellFrontSprite;
    }
}