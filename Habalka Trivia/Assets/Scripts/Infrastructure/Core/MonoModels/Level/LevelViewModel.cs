using System.Collections.Generic;
using UnityEngine;

namespace Trivia.Infrastructure.Core.MonoModels.Level
{
    public class LevelViewModel : MonoBehaviour
    {
        [SerializeField] private int _levelIndex = 0;
        [SerializeField] private List<LevelElementViewModel> _levelElements = new List<LevelElementViewModel>();

        [Header("Editor Only")]
        [SerializeField] private bool _showElementsGizmo = false;
        [SerializeField] private Color _gizmoColour = Color.black;
        [SerializeField] private Vector3 _elementScale = Vector3.one;

        public int LevelIndex => _levelIndex;
        public List<LevelElementViewModel> LevelElements => _levelElements;

        private void OnDrawGizmos()
        {
            #if UNITY_EDITOR
            if (!_showElementsGizmo)
            {
                return;
            }

            Gizmos.color = _gizmoColour;
            foreach (LevelElementViewModel element in _levelElements)
            {
                Transform elementTransform = element.transform;
                Gizmos.DrawCube(elementTransform.position, _elementScale);
            }
            
            #endif
        }
    }
}