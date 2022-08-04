using Trivia.Infrastructure.Core.StateManagement.Controller;

namespace Trivia.Infrastructure.Core.StateManagement.States
{
    public class LevelInitializeState : BaseLevelState
    {
        private LevelStateController _levelStateController;

        public override void Initialize(LevelStateController levelStateController)
        {
            base.Initialize(levelStateController);

            _levelStateController = levelStateController;
        }
    }
}