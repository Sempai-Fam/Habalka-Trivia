using Trivia.Infrastructure.UI.Panels.Base;
using UnityEngine;
using Zenject;

namespace Trivia.Infrastructure.UI.Panels.Test
{
    public class TestPanel : ObjectPanel
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
        
        public class Factory : PlaceholderFactory<TestPanel>
        {
        }
    }
}