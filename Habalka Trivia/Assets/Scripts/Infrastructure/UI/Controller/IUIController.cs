using Trivia.Infrastructure.UI.StaticData.UIWindowStaticData.Data;

namespace Trivia.Infrastructure.UI.Controller
{
    public interface IUIController
    {
        void ShowWindow(WindowType windowType);
        void CloseWindow(WindowType windowType);
        void CloseAllWindows();
    }
}