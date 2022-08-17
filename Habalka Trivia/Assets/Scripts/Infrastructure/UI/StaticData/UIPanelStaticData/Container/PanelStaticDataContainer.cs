using System.Collections.Generic;
using Trivia.Infrastructure.UI.StaticData.UIPanelStaticData.Data;
using UnityEngine;

namespace Trivia.Infrastructure.UI.StaticData.UIPanelStaticData.Container
{
    [CreateAssetMenu(menuName = "Configs/UI/Panels/Panel Container", fileName = "Panel_StaticData_Container")]
    public class PanelStaticDataContainer : ScriptableObject, IPanelStaticDataContainer
    {
        [SerializeField] private List<StaticPanelContainerData> _staticWindowContainerData = new List<StaticPanelContainerData>();

        public GameObject GetPanelPrefab(PanelType panelType)
        {
            return _staticWindowContainerData.Find(it => it.PanelType == panelType).PanelPrefab;
        }
    }
}