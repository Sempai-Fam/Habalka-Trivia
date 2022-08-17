using System.Collections.Generic;
using Trivia.Infrastructure.UI.Service.Factory.WindowFactory;
using Trivia.Infrastructure.UI.StaticData.UIWindowStaticData.Data;
using Trivia.Infrastructure.UI.Windows.Base;
using UnityEngine;
using Zenject;

namespace Trivia.Infrastructure.UI.Controller
{
    public class UIController : MonoBehaviour, IUIController
    {
        [SerializeField] private Transform _windowParent = null;

        private Dictionary<WindowType, ObjectWindow> _windowCache = null;
        private WindowFactoryService _windowFactoryService = null;

        [Inject]
        public void Construct(WindowFactoryService windowFactoryService)
        {
            _windowCache = new Dictionary<WindowType, ObjectWindow>();
            _windowFactoryService = windowFactoryService;
        }
        
        public void ShowWindow(WindowType windowType)
        {
            var window = _windowFactoryService.CreateWindow(windowType, _windowParent);
            CacheWindow(windowType, window);

            window.Initialize();
            window.Show();
        }

        public void CloseWindow(WindowType windowType)
        {
            if (_windowCache.ContainsKey(windowType))
            {
                RemoveWindowFromCache(windowType);
            }
            else
            {
                Debug.LogWarning($"No window cached of type {windowType}");
            }
        }

        public void CloseAllWindows()
        {
            foreach (var windowType in _windowCache.Keys)
            {
                var window = _windowCache[windowType];

                if (window != null)
                {
                    window.Close();
                }
            }
            
            _windowCache.Clear();
        }

        private void CacheWindow(WindowType windowType, ObjectWindow window)
        {
            if (_windowCache.ContainsKey(windowType))
            {
                var cachedWindow = _windowCache[windowType];
                if (cachedWindow != null)
                {
                    cachedWindow.Close();
                }

                RemoveWindowFromCache(windowType);
            }
            
            _windowCache.Add(windowType, window);
        }

        private void RemoveWindowFromCache(WindowType windowType)
        {
            _windowCache[windowType].Close();
            _windowCache.Remove(windowType);
        }
    }
}