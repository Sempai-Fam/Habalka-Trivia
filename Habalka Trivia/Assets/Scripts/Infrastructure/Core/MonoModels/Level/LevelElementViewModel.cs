using System.Collections.Generic;
using UnityEngine;

namespace Trivia.Infrastructure.Core.MonoModels.Level
{
    public class LevelElementViewModel : MonoBehaviour
    {
        [SerializeField] private List<LevelElementViewModel> _neighbourElements = new List<LevelElementViewModel>();

        public IEnumerable<LevelElementViewModel> NeighbourElements => _neighbourElements;
    }
}