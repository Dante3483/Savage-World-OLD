using SavageWorld.Runtime.Utilities.StateMachine;

namespace SavageWorld.Runtime.UI.MainMenu.States
{
    public class MainMenuState : StateBase
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public MainMenuState(IStateMachine stateMachine)
            : base(stateMachine) { }

        public override void Enter()
        {
            UIManager.Instance.MainMenuStore.MainPanel.Show();
        }

        public override void Exit()
        {
            UIManager.Instance.MainMenuStore.MainPanel.Hide();
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
