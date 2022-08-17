using System;
using UnityEngine;

namespace Trivia.Infrastructure.UI.StaticData.UIWindowStaticData.Data
{
    [Serializable]
    public class StaticWindowContainerData
    {
        [SerializeField] private WindowType _windowType;
        [SerializeField] private GameObject _windowPrefab;

        public WindowType WindowType => _windowType;
        public GameObject WindowPrefab => _windowPrefab;
    }
}