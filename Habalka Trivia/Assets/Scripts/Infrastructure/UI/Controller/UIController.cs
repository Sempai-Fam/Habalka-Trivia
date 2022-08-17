using System.Collections.Generic;
using Trivia.Infrastructure.UI.Panels.Base;
using Trivia.Infrastructure.UI.Service.Factory.PanelFactory;
using Trivia.Infrastructure.UI.Service.Factory.WindowFactory;
using Trivia.Infrastructure.UI.StaticData.UIPanelStaticData.Data;
using Trivia.Infrastructure.UI.StaticData.UIWindowStaticData.Data;
using Trivia.Infrastructure.UI.Windows.Base;
using UnityEngine;
using Zenject;

namespace Trivia.Infrastructure.UI.Controller
{
    public class UIController : MonoBehaviour, IUIController
    {
        [Header("Window Components")]
        [SerializeField] private Transform _windowParent = null;
        [SerializeField] private GameObject _windowFadeObject = null;

        [Header("Panel Components")] 
        [SerializeField] private Transform _panelParent = null;

        private readonly Dictionary<WindowType, ObjectWindow> _windowCache = new Dictionary<WindowType, ObjectWindow>();
        private readonly Dictionary<PanelType, ObjectPanel> _panelCache = new Dictionary<PanelType, ObjectPanel>();
        
        private IWindowFactoryService _windowFactoryService = null;
        private IPanelFactoryService _panelFactoryService = null;

        [Inject]
        public void Construct(IWindowFactoryService windowFactoryService, IPanelFactoryService panelFactoryService)
        {
            _windowFactoryService = windowFactoryService;
            _panelFactoryService = panelFactoryService;
        }
        
        public void ShowWindow(WindowType windowType)
        {
            var window = _windowFactoryService.CreateWindow(windowType, _windowParent);
            CacheWindow(windowType, window);

            window.Initialize();
            window.Show();
            ChangeWindowState();
        }

        public void ShowPanel(PanelType panelType)
        {
            var panel = _panelFactoryService.CreatePanel(panelType, _panelParent);
            CachePanel(panelType, panel);
            
            panel.Initialize();
            panel.Show();
        }

        public void CloseWindow(WindowType windowType)
        {
            if (IsWindowCached(windowType))
            {
                RemoveWindowFromCache(windowType);
            }
            else
            {
                Debug.LogWarning($"No window cached of type {windowType}");
            }
            
            ChangeWindowState();
        }

        public void ClosePanel(PanelType panelType)
        {
            if (IsPanelCached(panelType))
            {
                RemovePanelFromCache(panelType);
            }
            else
            {
                Debug.LogWarning($"No panel cached of type {panelType}");
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
            ChangeWindowState();
        }

        public void CloseAllPanels()
        {
            foreach (var panelType in _panelCache.Keys)
            {
                var panel = _panelCache[panelType];

                if (panel != null)
                {
                    panel.Close();
                }
            }
            
            _windowCache.Clear();
        }

        private bool IsWindowCached(WindowType windowType)
        {
            return _windowCache.ContainsKey(windowType);
        }

        private bool IsPanelCached(PanelType panelType)
        {
            return _panelCache.ContainsKey(panelType);
        }

        private void CacheWindow(WindowType windowType, ObjectWindow window)
        {
            if (IsWindowCached(windowType))
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

        private void CachePanel(PanelType panelType, ObjectPanel panel)
        {
            if (IsPanelCached(panelType))
            {
                var cachedPanel = _panelCache[panelType];
                if (cachedPanel != null)
                {
                    cachedPanel.Close();
                }

                RemovePanelFromCache(panelType);
            }
            
            _panelCache.Add(panelType, panel);
        }

        private void RemoveWindowFromCache(WindowType windowType)
        {
            _windowCache[windowType].Close();
            _windowCache.Remove(windowType);
        }

        private void RemovePanelFromCache(PanelType panelType)
        {
            _panelCache[panelType].Close();
            _panelCache.Remove(panelType);
        }

        private void ChangeWindowState()
        {
            _windowFadeObject.SetActive(false);

            if (_windowCache.Count == 0)
                return;
            
            _windowFadeObject.transform.SetAsLastSibling();
            _windowFadeObject.SetActive(true);
        }
    }
}