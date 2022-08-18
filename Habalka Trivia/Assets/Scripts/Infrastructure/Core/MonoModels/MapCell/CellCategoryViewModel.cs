using System.Collections.Generic;
using Trivia.Infrastructure.Core.Data.CellCategoryType;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Trivia.Infrastructure.Core.MonoModels.MapCell
{
    public class CellCategoryViewModel : MonoBehaviour
    {
        [SerializeField] private int _cellIndex = 0;
        [SerializeField] private EventTrigger _cellEventTrigger = null;
        [SerializeField] private SpriteRenderer _cellBackImage = null;
        [SerializeField] private SpriteRenderer _cellBackImageTemp = null;
        [SerializeField] private SpriteRenderer _cellFrontImage = null;
        [SerializeField] private List<CellCategoryViewModel> _cellNeighbours = new List<CellCategoryViewModel>();

        public int CellIndex => _cellIndex;
        public CellCategoryStatusType CellCategoryStatusType { get; set; }
        public EventTrigger CellEventTrigger => _cellEventTrigger;
        public SpriteRenderer CellBackImage => _cellBackImage;
        public SpriteRenderer CellBackImageTemp => _cellBackImageTemp;
        public SpriteRenderer CellFrontImage => _cellFrontImage;
        public IEnumerable<CellCategoryViewModel> CellNeighbours => _cellNeighbours;
    }
}