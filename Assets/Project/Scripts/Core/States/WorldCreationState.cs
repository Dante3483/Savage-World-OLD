using System.Threading.Tasks;
using SavageWorld.Runtime.Enums.StateMachine;
using SavageWorld.Runtime.UI;
using SavageWorld.Runtime.Utilities;
using SavageWorld.Runtime.Utilities.StateMachine;

namespace SavageWorld.Runtime.Core.States
{
    public class WorldCreationState : StateBase
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public WorldCreationState(IStateMachine stateMachine)
            : base(stateMachine) { }

        public override void Enter()
        {
            UIManager.Instance.MainMenuStore.LoadingPanel.Show();
            Task.Run(StartCreation);
        }

        public override void Exit()
        {
            UIManager.Instance.MainMenuStore.LoadingPanel.Hide();
        }
        #endregion

        #region Private Methods
        private void StartCreation()
        {
            GameManager.Instance.WorldBuilder.GenerateWorld(GameManager.Instance.WorldConfig);
            MainThread.Instance.Execute(CompleteCreation);
        }

        private void CompleteCreation()
        {
            GameManager.Instance.ChangeState(GameStateType.Gameplay);
        }
        #endregion
    }
}
