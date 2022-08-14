using Trivia.Infrastructure.Core.StateManagement.Controller;

namespace Trivia.Infrastructure.Core.StateManagement.States
{
    public class CoreBaseState : ICoreState
    {
        public virtual void Initialize(CoreStateController coreStateController)
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