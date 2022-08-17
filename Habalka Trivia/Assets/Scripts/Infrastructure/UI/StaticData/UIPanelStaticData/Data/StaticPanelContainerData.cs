using System;
using UnityEngine;

namespace Trivia.Infrastructure.UI.StaticData.UIPanelStaticData.Data
{
    [Serializable]
    public class StaticPanelContainerData
    {
        [SerializeField] private PanelType _panelType = PanelType.None;
        [SerializeField] private GameObject _panelPrefab = null;

        public PanelType PanelType => _panelType;
        public GameObject PanelPrefab => _panelPrefab;
    }
}