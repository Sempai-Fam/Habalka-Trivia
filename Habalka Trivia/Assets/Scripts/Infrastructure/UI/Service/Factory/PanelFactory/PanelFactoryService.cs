using Trivia.Infrastructure.UI.Panels.Base;
using Trivia.Infrastructure.UI.Panels.Test;
using Trivia.Infrastructure.UI.StaticData.UIPanelStaticData.Data;
using UnityEngine;
using Zenject;

namespace Trivia.Infrastructure.UI.Service.Factory.PanelFactory
{
    public class PanelFactoryService : IPanelFactoryService
    {
        private readonly TestPanel.Factory _testPanelFactory;

        public PanelFactoryService(TestPanel.Factory testPanelFactory)
        {
            _testPanelFactory = testPanelFactory;
        }

        public ObjectPanel CreatePanel(PanelType panelType, Transform panelParent)
        {
            return GetPanelByType(panelType, panelParent);
        }

        private TestPanel CreateTestWindow(Transform parent)
        {
            var testWindow = CreatePanelFromFactory(_testPanelFactory, parent);

            return testWindow;
        }
        
        private ObjectPanel GetPanelByType(PanelType panelType, Transform parent)
        {
            ObjectPanel panel = null;
            
            switch (panelType)
            {
                case PanelType.TestPanel:
                    panel = CreateTestWindow(parent);
                    break;
            }

            return panel;
        }
        
        private T CreatePanelFromFactory<T>(PlaceholderFactory<T> factory, Transform parent) where T : ObjectPanel
        {
            var panel = factory.Create();
            panel.SetParent(parent);

            return panel;
        }
    }
}