using System.Threading.Tasks;
using SavageWorld.Runtime.UI;
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
            Task.Run(() => GameManager.Instance.WorldBuilder.GenerateWorld());
        }

        public override void Exit()
        {
            UIManager.Instance.MainMenuStore.LoadingPanel.Hide();
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
