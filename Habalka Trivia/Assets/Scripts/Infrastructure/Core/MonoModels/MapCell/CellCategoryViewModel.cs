using Trivia.Infrastructure.Core.Data.CellCategoryType;
using Trivia.Infrastructure.Core.MonoModels.Level;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Trivia.Infrastructure.Core.MonoModels.MapCell
{
    public class CellCategoryViewModel : MonoBehaviour
    {
        [SerializeField] private EventTrigger _cellEventTrigger = null;
        [SerializeField] private SpriteRenderer _cellBackImage = null;
        [SerializeField] private SpriteRenderer _cellBackImageTemp = null;
        [SerializeField] private SpriteRenderer _cellFrontImage = null;

        private int _cellIndex = 0;
        private LevelElementViewModel _elementViewModel = null;
        
        public int CellIndex => _cellIndex;
        public CellCategoryStatusType CurrentStatusType { get; set; }
        public EventTrigger CellEventTrigger => _cellEventTrigger;
        public SpriteRenderer CellBackImage => _cellBackImage;
        public SpriteRenderer CellBackImageTemp => _cellBackImageTemp;
        public SpriteRenderer CellFrontImage => _cellFrontImage;
        public LevelElementViewModel ElementViewModel => _elementViewModel;

        [Inject]
        public void Construct(Vector3 positionTransform)
        {
            transform.position = positionTransform;
        }
        
        public void Initialize(int cellIndex, LevelElementViewModel elementViewModel)
        {
            _cellIndex = cellIndex;
            _elementViewModel = elementViewModel;
        }
        
        public class Factory : PlaceholderFactory<Vector3, CellCategoryViewModel>
        {
        }
    }
}