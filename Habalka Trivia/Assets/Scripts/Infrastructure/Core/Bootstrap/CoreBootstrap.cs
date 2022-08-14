using Trivia.Infrastructure.Core.StateManagement.Controller;
using Trivia.Infrastructure.Core.StateManagement.Data;
using Zenject;

namespace Trivia.Infrastructure.Core.Bootstrap
{
    public class CoreBootstrap : IInitializable
    {
        private readonly CoreStateController _controller;

        [Inject]
        public CoreBootstrap(CoreStateController controller)
        {
            _controller = controller;

        }

        public void Initialize()
        {
            _controller.SwitchState(LevelStateType.CoreEnter);
        }
    }
}