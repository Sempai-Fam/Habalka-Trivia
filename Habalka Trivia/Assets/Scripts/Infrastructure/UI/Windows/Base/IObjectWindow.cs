using UnityEngine;

namespace Trivia.Infrastructure.UI.Windows.Base
{
    public interface IObjectWindow
    {
        void Initialize();
        void Show();
        void Close();
    }
}