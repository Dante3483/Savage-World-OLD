using System.Collections.Generic;

namespace SavageWorld.Runtime.Utilities.StateMachine
{
    public class StateMachine : IStateMachine
    {
        #region Fields
        private Dictionary<int, IState> _states = new();
        private IState _currentState;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public bool RegisterState(int stateId, IState state)
        {
            return _states.TryAdd(stateId, state);
        }

        public virtual bool ChangeState(int stateId)
        {
            if (!_states.TryGetValue(stateId, out var state))
            {
                return false;
            }
            if (_currentState != null)
            {
                _currentState.Exit();
            }
            _currentState = state;
            _currentState.Enter();
            return true;
        }

        public virtual void Reset()
        {
            _currentState?.Exit();
            _currentState = null;
        }

        public virtual void FixedUpdate()
        {
            _currentState?.FixedUpdate();
        }

        public virtual void Update()
        {
            _currentState?.Update();
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
