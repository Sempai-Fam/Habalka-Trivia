using Trivia.Infrastructure.UI.Panels.Base;
using Trivia.Infrastructure.UI.StaticData.UIPanelStaticData.Data;
using UnityEngine;

namespace Trivia.Infrastructure.UI.Service.Factory.PanelFactory
{
    public interface IPanelFactoryService
    {
        ObjectPanel CreatePanel(PanelType panelType, Transform panelParent);
    }
}