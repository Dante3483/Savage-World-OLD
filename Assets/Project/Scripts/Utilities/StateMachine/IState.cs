namespace SavageWorld.Runtime.Utilities.StateMachine
{
    public interface IState
    {
        #region Properties

        #endregion

        #region Public Methods
        public void Enter();
        public void Exit();
        public void Update();
        public void FixedUpdate();
        #endregion
    }
}
