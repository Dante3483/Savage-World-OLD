using SavageWorld.Runtime.Utilities.StateMachine;

namespace SavageWorld.Runtime.UI.MainMenu.States
{
    public class NetworkSettingsState : StateBase
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public NetworkSettingsState(IStateMachine stateMachine)
            : base(stateMachine) { }

        public override void Enter()
        {
            UIManager.Instance.MainMenuStore.NetworkSettingsPanel.Show();
        }

        public override void Exit()
        {
            UIManager.Instance.MainMenuStore.NetworkSettingsPanel.Hide();
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
