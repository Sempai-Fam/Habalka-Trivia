using System.Collections.Generic;
using Trivia.Infrastructure.Core.MonoModels.MapCell;
using UnityEngine;

namespace Trivia.Infrastructure.Core.MonoModels.Map
{
    public class MapViewModel : MonoBehaviour
    {   
        [SerializeField] private List<CellCategoryViewModel> _mapCellList = new List<CellCategoryViewModel>();
        
        public IEnumerable<CellCategoryViewModel> MapCellViewModels => _mapCellList;
    }
}