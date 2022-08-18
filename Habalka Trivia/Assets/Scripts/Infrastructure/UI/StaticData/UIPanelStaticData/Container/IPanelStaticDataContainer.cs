using Trivia.Infrastructure.UI.StaticData.UIPanelStaticData.Data;
using UnityEngine;

namespace Trivia.Infrastructure.UI.StaticData.UIPanelStaticData.Container
{
    public interface IPanelStaticDataContainer
    {
        GameObject GetPanelPrefab(PanelType panelType);
    }
}