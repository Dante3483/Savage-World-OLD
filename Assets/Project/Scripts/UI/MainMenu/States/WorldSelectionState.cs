using SavageWorld.Runtime.Utilities.StateMachine;

namespace SavageWorld.Runtime.UI.MainMenu.States
{
    public class WorldSelectionState : StateBase
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public WorldSelectionState(IStateMachine stateMachine)
            : base(stateMachine) { }

        public override void Enter()
        {
            UIManager.Instance.MainMenuStore.WorldSelectionPanel.Show();
        }

        public override void Exit()
        {
            UIManager.Instance.MainMenuStore.WorldSelectionPanel.Hide();
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
