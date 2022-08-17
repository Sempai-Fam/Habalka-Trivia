using UnityEngine;

namespace Trivia.Infrastructure.UI.Windows.Base
{
    public interface IObjectWindow
    {
        void SetParent(Transform parent);
        void Initialize();
        void Show();
        void Close();
    }
}