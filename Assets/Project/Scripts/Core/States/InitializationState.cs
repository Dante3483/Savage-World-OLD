using System;
using System.Threading.Tasks;
using SavageWorld.Runtime.Enums.StateMachine;
using SavageWorld.Runtime.UI;
using SavageWorld.Runtime.Utilities;
using SavageWorld.Runtime.Utilities.StateMachine;
using SavageWorld.Runtime.World;

namespace SavageWorld.Runtime.Core.States
{
    public class InitializationState : StateBase
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public InitializationState(IStateMachine stateMachine)
            : base(stateMachine) { }

        public override void Enter()
        {
            UIManager.Instance.MainMenuStore.LoadingPanel.Show();
            Task.Run(StartInitialization);
        }

        public override void Exit()
        {
            UIManager.Instance.MainMenuStore.LoadingPanel.Hide();
        }
        #endregion

        #region Private Methods
        private void StartInitialization()
        {
            var steps = new Action[] { InitializeData };
            var progressBar = UIManager.Instance.MainMenuStore.LoadingProgressBar;
            var valuePerStep = progressBar.MaxValue / steps.Length;
            foreach (var step in steps)
            {
                step?.Invoke();
                progressBar.IncreaseValue(valuePerStep);
            }
            MainThread.Instance.Execute(CompleteInitialization);
        }

        private void CompleteInitialization()
        {
            GameManager.Instance.ChangeState(GameStateType.MainMenu);
        }

        private void InitializeData()
        {
            TilesManager.Instance.Initialize();
        }
        #endregion
    }
}
