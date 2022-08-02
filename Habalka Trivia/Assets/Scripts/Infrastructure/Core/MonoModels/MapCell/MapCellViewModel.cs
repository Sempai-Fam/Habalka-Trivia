using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Trivia.Infrastructure.Core.MonoModels.MapCell
{
    public class MapCellViewModel : MonoBehaviour
    {
        [SerializeField] private int _cellIndex = 0;
        [SerializeField] private Button _cellButton = null;
        [SerializeField] private Image _cellCategoryImage = null;
        [SerializeField] private List<MapCellViewModel> _cellNeighbours = new List<MapCellViewModel>();

        public int CellIndex => _cellIndex;
        public MapCellStatusType MapCellStatusType { get; set; }
        public Button CellButton => _cellButton;
        public Image CellCategoryImage => _cellCategoryImage;
        public IEnumerable<MapCellViewModel> CellNeighbours => _cellNeighbours;
    }
}