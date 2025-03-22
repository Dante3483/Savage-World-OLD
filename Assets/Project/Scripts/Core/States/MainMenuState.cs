using SavageWorld.Runtime.Enums.StateMachine;
using SavageWorld.Runtime.Utilities.StateMachine;

namespace SavageWorld.Runtime.Core.States
{
    public class MainMenuState : State
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
            GameManager.Instance.ManagersStore.MainMenuManager.ChangeState(
                Enums.StateMachine.MainMenuStateType.Initial
            );
        }

        public override void Exit()
        {
            GameManager.Instance.ManagersStore.MainMenuManager.ResetStateMachine();
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
