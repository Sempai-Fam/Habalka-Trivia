using Trivia.Infrastructure.UI.StaticData.UIWindowStaticData.Data;
using UnityEngine;

namespace Trivia.Infrastructure.UI.StaticData.UIWindowStaticData.Container
{
    public interface IWindowStaticDataContainer
    {
        GameObject GetWindowPrefab(WindowType windowType);
    }
}