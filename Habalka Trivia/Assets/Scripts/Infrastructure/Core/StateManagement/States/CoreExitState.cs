using Trivia.Infrastructure.Core.StateManagement.Controller;

namespace Trivia.Infrastructure.Core.StateManagement.States
{
    public class CoreExitState : CoreBaseState
    {
        private CoreStateController _coreStateController;

        public override void Initialize(CoreStateController coreStateController)
        {
            base.Initialize(coreStateController);

            _coreStateController = coreStateController;
        }
    }
}