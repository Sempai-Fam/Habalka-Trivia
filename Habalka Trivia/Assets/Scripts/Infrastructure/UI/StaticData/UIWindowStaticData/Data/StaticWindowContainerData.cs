using System;
using UnityEngine;

namespace Trivia.Infrastructure.UI.StaticData.UIWindowStaticData.Data
{
    [Serializable]
    public class StaticWindowContainerData
    {
        [SerializeField] private WindowType _windowType = WindowType.None;
        [SerializeField] private GameObject _windowPrefab = null;

        public WindowType WindowType => _windowType;
        public GameObject WindowPrefab => _windowPrefab;
    }
}