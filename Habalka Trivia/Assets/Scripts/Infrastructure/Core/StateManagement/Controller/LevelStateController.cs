using System.Collections.Generic;
using Trivia.Infrastructure.Core.StateManagement.Data;
using Trivia.Infrastructure.Core.StateManagement.States;
using Zenject;

namespace Trivia.Infrastructure.Core.StateManagement.Controller
{
    public class LevelStateController : IInitializable, ILateDisposable
    {
        private Dictionary<LevelStateType, BaseLevelState> _cachedStates = null;
        private BaseLevelState _currentState = null;

        public LevelStateController(LevelInitializeState levelInitializeState,
            LevelDisposeState levelDisposeState,
            LevelUpdateState levelUpdateState,
            OpenQuizState openQuizState)
        {
            _cachedStates = new Dictionary<LevelStateType, BaseLevelState>()
            {
                { LevelStateType.LevelInitState, levelInitializeState },
                { LevelStateType.LevelDisposeState, levelDisposeState },
                { LevelStateType.LevelUpdateState, levelUpdateState },
                { LevelStateType.OpenQuizState, openQuizState },
            };
        }
        
        public void Initialize()
        {
            foreach (BaseLevelState state in _cachedStates.Values)
            {
                state.Initialize(this);
            }
        }

        public void LateDispose()
        {
            foreach (BaseLevelState state in _cachedStates.Values)
            {
                state.Dispose();
            }
        }
        
        public void SwitchState(LevelStateType type)
        {
            var nextState = GetNextState(type);
            
            ClosePreviousState();

            if (nextState != null)
            {
                _currentState = nextState;
            }
            
            _currentState?.Enter();
        }

        private BaseLevelState GetNextState(LevelStateType type)
        {
            if (_cachedStates.ContainsKey(type))
            {
                return _cachedStates[type];
            }

            return null;
        }

        private void ClosePreviousState()
        {
            _currentState?.Exit();
        }
    }
}