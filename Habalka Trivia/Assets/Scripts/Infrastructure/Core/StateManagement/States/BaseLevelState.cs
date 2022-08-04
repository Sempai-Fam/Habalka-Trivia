using Trivia.Infrastructure.Core.StateManagement.Controller;

namespace Trivia.Infrastructure.Core.StateManagement.States
{
    public class BaseLevelState : ILevelState
    {
        public virtual void Initialize(LevelStateController levelStateController)
        {
        }

        public virtual void Enter()
        {
        }

        public virtual void Dispose()
        {
        }

        public virtual void Exit()
        {
        }
    }
}