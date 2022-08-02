using System.Collections.Generic;
using Trivia.Infrastructure.Core.MonoModels.MapCell;
using UnityEngine;

namespace Trivia.Infrastructure.Core.MonoModels.Map
{
    public class MapViewModel : MonoBehaviour
    {   
        [SerializeField] private List<MapCellViewModel> _mapCellList = new List<MapCellViewModel>();
        
        public IEnumerable<MapCellViewModel> MapCellViewModels => _mapCellList;
    }
}