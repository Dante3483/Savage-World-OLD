using SavageWorld.Runtime.Utilities.StateMachine;

namespace SavageWorld.Runtime.UI.MainMenu.States
{
    public class PlayerSelectionState : State
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public PlayerSelectionState(IStateMachine stateMachine)
            : base(stateMachine) { }

        public override void Enter()
        {
            UIManager.Instance.MainMenuStore.PlayerSelectionPanel.Show();
        }

        public override void Exit()
        {
            UIManager.Instance.MainMenuStore.PlayerSelectionPanel.Hide();
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
