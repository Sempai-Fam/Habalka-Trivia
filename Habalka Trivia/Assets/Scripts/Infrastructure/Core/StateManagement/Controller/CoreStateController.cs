using System.Collections.Generic;
using Trivia.Infrastructure.Core.StateManagement.Data;
using Trivia.Infrastructure.Core.StateManagement.States;
using Zenject;

namespace Trivia.Infrastructure.Core.StateManagement.Controller
{
    public class CoreStateController : IInitializable, ILateDisposable
    {
        private Dictionary<LevelStateType, CoreBaseState> _cachedStates = null;
        private CoreBaseState _currentState = null;

        public CoreStateController(CoreEnterState coreEnterState,
            CoreExitState coreExitState,
            CoreUpdateState coreUpdateState)
        {
            _cachedStates = new Dictionary<LevelStateType, CoreBaseState>()
            {
                { LevelStateType.CoreEnter, coreEnterState },
                { LevelStateType.CoreUpdate, coreExitState },
                { LevelStateType.CoreExit, coreUpdateState },
            };
        }
        
        public void Initialize()
        {
            foreach (CoreBaseState state in _cachedStates.Values)
            {
                state.Initialize(this);
            }
        }

        public void LateDispose()
        {
            foreach (CoreBaseState state in _cachedStates.Values)
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

        private CoreBaseState GetNextState(LevelStateType type)
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