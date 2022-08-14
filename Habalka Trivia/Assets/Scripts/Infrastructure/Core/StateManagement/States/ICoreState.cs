using Trivia.Infrastructure.Core.StateManagement.Controller;

namespace Trivia.Infrastructure.Core.StateManagement.States
{
    public interface ICoreState
    {
        void Initialize(CoreStateController coreStateController);
        void Enter();
        void Dispose();
        void Exit();
    }
}