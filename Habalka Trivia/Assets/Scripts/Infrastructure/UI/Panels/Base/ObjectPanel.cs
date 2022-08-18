using Trivia.Infrastructure.UI.UIStructure;
using UnityEngine;

namespace Trivia.Infrastructure.UI.Panels.Base
{
    public abstract class ObjectPanel : UIElement, IUIElement, IObjectPanel
    {
        public abstract void SetParent(Transform parent);

        public abstract void Initialize();

        public abstract void Show();

        public abstract void Close();
    }
}