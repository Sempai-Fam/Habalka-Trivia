using Trivia.Infrastructure.UI.Windows.Base;
using UnityEngine;
using Zenject;

namespace Trivia.Infrastructure.UI.Windows.Test
{
    public class TestWindow : ObjectWindow
    {
        public override void SetParent(Transform parent)
        {
        }

        public override void Initialize()
        {
        }

        public override void Show()
        {
        }

        public override void Close()
        {
        }
        
        public class Factory : PlaceholderFactory<TestWindow>
        {
        }
    }
}