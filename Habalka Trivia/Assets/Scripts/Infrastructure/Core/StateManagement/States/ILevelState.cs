using Trivia.Infrastructure.Core.StateManagement.Controller;

namespace Trivia.Infrastructure.Core.StateManagement.States
{
    public interface ILevelState
    {
        void Initialize(LevelStateController levelStateController);
        void Enter();
        void Dispose();
        void Exit();
    }
}