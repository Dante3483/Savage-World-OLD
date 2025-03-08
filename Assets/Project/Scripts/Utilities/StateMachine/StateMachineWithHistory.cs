using System.Collections.Generic;

namespace SavageWorld.Runtime.Utilities.StateMachine
{
    public class StateMachineWithHistory : StateMachine
    {
        #region Fields
        private readonly Stack<int> _stateHistory = new();
        private int _currentStateId = -1;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public override bool ChangeState(int stateId)
        {
            if (_currentStateId != -1)
            {
                _stateHistory.Push(_currentStateId);
            }
            if (base.ChangeState(stateId))
            {
                _currentStateId = stateId;
                return true;
            }
            return false;
        }

        public void GoBack()
        {
            if (_stateHistory.Count == 0)
            {
                return;
            }
            _currentStateId = _stateHistory.Pop();
            base.ChangeState(_currentStateId);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
