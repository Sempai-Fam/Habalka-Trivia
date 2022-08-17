using Trivia.Infrastructure.UI.StaticData.UIWindowStaticData.Data;
using Trivia.Infrastructure.UI.Windows.Base;
using UnityEngine;

namespace Trivia.Infrastructure.UI.Service.Factory.WindowFactory
{
    public interface IWindowFactoryService
    {
        ObjectWindow CreateWindow(WindowType windowType, Transform parent);
    }
}