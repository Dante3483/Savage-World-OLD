using SavageWorld.Runtime.Enums.StateMachine;
using SavageWorld.Runtime.UI.MainMenu.States;
using SavageWorld.Runtime.Utilities.StateMachine;
using UnityEngine;

namespace SavageWorld.Runtime.UI.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        #region Fields
        private IStateMachine _stateMachine;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods
        private void Awake()
        {
            _stateMachine = new StateMachine();
        }

        private void Start()
        {
            _stateMachine.RegisterState((int)MainMenuStateType.MainMenu, new MainMenuState());
            _stateMachine.RegisterState(
                (int)MainMenuStateType.PlayerSelection,
                new PlayerSelectionState()
            );
            _stateMachine.RegisterState(
                (int)MainMenuStateType.WorldSelection,
                new WorldSelectionState()
            );
            _stateMachine.RegisterState(
                (int)MainMenuStateType.NetworkSettings,
                new NetworkSettingsState()
            );
            _stateMachine.RegisterState(
                (int)MainMenuStateType.ConnectViaIP,
                new ConnectViaIPState()
            );
            _stateMachine.RegisterState((int)MainMenuStateType.HostAndPlay, new HostAndPlayState());
            _stateMachine.RegisterState((int)MainMenuStateType.Settings, new SettingsState());
            _stateMachine.ChangeState((int)MainMenuStateType.MainMenu);
        }
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
