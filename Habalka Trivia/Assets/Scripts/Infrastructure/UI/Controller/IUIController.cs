using Trivia.Infrastructure.UI.StaticData.UIPanelStaticData.Data;
using Trivia.Infrastructure.UI.StaticData.UIWindowStaticData.Data;

namespace Trivia.Infrastructure.UI.Controller
{
    public interface IUIController
    {
        void ShowWindow(WindowType windowType);
        void ShowPanel(PanelType panelType);
        void CloseWindow(WindowType windowType);
        void ClosePanel(PanelType panelType);
        void CloseAllWindows();
        void CloseAllPanels();
    }
}