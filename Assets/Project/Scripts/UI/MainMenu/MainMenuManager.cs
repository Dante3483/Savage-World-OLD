using SavageWorld.Runtime.Enums.StateMachine;
using SavageWorld.Runtime.UI.MainMenu.SectionHandlers;
using SavageWorld.Runtime.UI.MainMenu.States;
using SavageWorld.Runtime.Utilities.StateMachine;
using UnityEngine;

namespace SavageWorld.Runtime.UI.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        #region Fields
        private IStateMachine _stateMachine;

        [SerializeField]
        private StarterSectionHandler _starterSectionHandler;

        [SerializeField]
        private MultiplayerSectionHandler _multiplayerSectionHandler;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods
        private void Awake()
        {
            _stateMachine = new StateMachine();
            _starterSectionHandler.SetManager(this);
            _multiplayerSectionHandler.SetManager(this);
        }

        private void Start()
        {
            RegisterStates();
            ChangeState(MainMenuStateType.MainMenu);
        }

        private void OnEnable()
        {
            _starterSectionHandler.AddListeners();
            _multiplayerSectionHandler.AddListeners();
        }

        private void OnDisable()
        {
            _starterSectionHandler.RemoveListeners();
            _multiplayerSectionHandler.RemoveListeners();
        }
        #endregion

        #region Public Methods
        public void ChangeState(MainMenuStateType newState)
        {
            _stateMachine.ChangeState((int)newState);
        }
        #endregion

        #region Private Methods
        private void RegisterStates()
        {
            _stateMachine.RegisterState(
                (int)MainMenuStateType.MainMenu,
                new MainMenuState(_stateMachine)
            );
            _stateMachine.RegisterState(
                (int)MainMenuStateType.PlayerSelection,
                new PlayerSelectionState(_stateMachine)
            );
            _stateMachine.RegisterState(
                (int)MainMenuStateType.WorldSelection,
                new WorldSelectionState(_stateMachine)
            );
            _stateMachine.RegisterState(
                (int)MainMenuStateType.NetworkSettings,
                new NetworkSettingsState(_stateMachine)
            );
            _stateMachine.RegisterState(
                (int)MainMenuStateType.ConnectViaIP,
                new ConnectViaIPState(_stateMachine)
            );
            _stateMachine.RegisterState(
                (int)MainMenuStateType.HostAndPlay,
                new HostAndPlayState(_stateMachine)
            );
            _stateMachine.RegisterState(
                (int)MainMenuStateType.Settings,
                new SettingsState(_stateMachine)
            );
        }
        #endregion
    }
}
