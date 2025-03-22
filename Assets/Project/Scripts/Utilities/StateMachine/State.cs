namespace SavageWorld.Runtime.Utilities.StateMachine
{
    public abstract class State : IState
    {
        #region Fields
        protected IStateMachine _stateMachine;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public State(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public abstract void Enter();

        public abstract void Exit();

        public virtual void FixedUpdate() { }

        public virtual void Update() { }
        #endregion

        #region Private Methods

        #endregion
    }
}
