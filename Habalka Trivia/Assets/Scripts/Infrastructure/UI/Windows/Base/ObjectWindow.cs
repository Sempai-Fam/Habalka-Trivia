using Trivia.Infrastructure.UI.UIStructure;
using UnityEngine;

namespace Trivia.Infrastructure.UI.Windows.Base
{
    public abstract class ObjectWindow : UIElement, IObjectWindow
    {
        public abstract void SetParent(Transform parent);

        public abstract void Initialize();

        public abstract void Show();

        public abstract void Close();
    }
}