using SavageWorld.Runtime.Utilities.StateMachine;

namespace SavageWorld.Runtime.UI.MainMenu.States
{
    public class InitialState : StateBase
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public InitialState(IStateMachine stateMachine)
            : base(stateMachine) { }

        public override void Enter()
        {
            UIManager.Instance.MainMenuStore.InitialPanel.Show();
        }

        public override void Exit()
        {
            UIManager.Instance.MainMenuStore.InitialPanel.Hide();
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
