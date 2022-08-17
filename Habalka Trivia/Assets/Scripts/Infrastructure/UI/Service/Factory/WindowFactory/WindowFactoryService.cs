using Trivia.Infrastructure.UI.StaticData.UIWindowStaticData.Data;
using Trivia.Infrastructure.UI.Windows.Base;
using Trivia.Infrastructure.UI.Windows.Test;
using UnityEngine;
using Zenject;

namespace Trivia.Infrastructure.UI.Service.Factory.WindowFactory
{
    public class WindowFactoryService
    {
        private readonly TestWindow.Factory _testWindowFactory;

        public WindowFactoryService(TestWindow.Factory testWindowFactory)
        {
            _testWindowFactory = testWindowFactory;
        }

        public ObjectWindow CreateWindow(WindowType windowType, Transform parent)
        {
            return GetWindowByType(windowType, parent);
        }

        private TestWindow CreateTestWindow(Transform parent)
        {
            var testWindow = CreateWindowFromFactory(_testWindowFactory, parent);

            return testWindow;
        }

        private ObjectWindow GetWindowByType(WindowType windowType, Transform parent)
        {
            ObjectWindow window = null;
            
            switch (windowType)
            {
                case WindowType.Test:
                    window = CreateTestWindow(parent);
                    break;
            }

            return window;
        }
        
        private T CreateWindowFromFactory<T>(PlaceholderFactory<T> factory, Transform parent) where T : ObjectWindow
        {
            var window = factory.Create();
            window.SetParent(parent);

            return window;
        }
    }
}