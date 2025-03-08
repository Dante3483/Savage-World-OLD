namespace SavageWorld.Runtime.Utilities.StateMachine
{
    public abstract class StateBase : IState
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public abstract void Enter();

        public abstract void Exit();

        public virtual void FixedUpdate() { }

        public virtual void Update() { }
        #endregion

        #region Private Methods

        #endregion
    }
}
