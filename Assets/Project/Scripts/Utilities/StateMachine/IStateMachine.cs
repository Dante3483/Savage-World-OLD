namespace SavageWorld.Runtime.Utilities.StateMachine
{
    public interface IStateMachine
    {
        #region Properties

        #endregion

        #region Public Methods
        public bool RegisterState(int stateId, IState state);

        public bool ChangeState(int stateId);

        public void Update();

        public void FixedUpdate();
        #endregion
    }
}
