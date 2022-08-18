using System.Collections.Generic;
using Trivia.Infrastructure.UI.StaticData.UIWindowStaticData.Data;
using UnityEngine;

namespace Trivia.Infrastructure.UI.StaticData.UIWindowStaticData.Container
{
    [CreateAssetMenu(menuName = "Configs/UI/Windows/Window Container", fileName = "Window_StaticData_Container")]
    public class WindowStaticDataContainer : ScriptableObject, IWindowStaticDataContainer
    {
        [SerializeField] private List<StaticWindowContainerData> _staticWindowContainerData = new List<StaticWindowContainerData>();

        public GameObject GetWindowPrefab(WindowType windowType)
        {
            return _staticWindowContainerData.Find(it => it.WindowType == windowType).WindowPrefab;
        }
    }
}