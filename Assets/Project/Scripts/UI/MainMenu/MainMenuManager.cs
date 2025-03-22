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
        private IStateMachine _stateMachine = new StateMachineWithHistory();

        [SerializeReference]
        private SectionHandler _initialSectionHandler = new InitialSectionHandler();

        [SerializeReference]
        private SectionHandler _multiplayerSectionHandler = new MultiplayerSectionHandler();

        [SerializeReference]
        private SectionHandler _playersSectionHandler = new PlayersSectionHandler();

        [SerializeReference]
        private SectionHandler _worldSelectionSectionHandler = new WorldsSectionHandler();
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods
        private void Awake()
        {
            InitializeHandlers();
            RegisterStates();
        }

        private void OnEnable()
        {
            _initialSectionHandler.AddListeners();
            _multiplayerSectionHandler.AddListeners();
            _playersSectionHandler.AddListeners();
            _worldSelectionSectionHandler.AddListeners();
        }

        private void OnDisable()
        {
            _initialSectionHandler.RemoveListeners();
            _multiplayerSectionHandler.RemoveListeners();
            _playersSectionHandler.RemoveListeners();
            _worldSelectionSectionHandler.RemoveListeners();
        }
        #endregion

        #region Public Methods
        public void ChangeState(MainMenuStateType newState)
        {
            _stateMachine.ChangeState((int)newState);
        }

        public void ResetStateMachine()
        {
            _stateMachine.Reset();
        }

        public void GoBack()
        {
            if (_stateMachine is StateMachineWithHistory stateMachineWithHistory)
            {
                stateMachineWithHistory.GoBack();
            }
        }
        #endregion

        #region Private Methods
        private void InitializeHandlers()
        {
            _initialSectionHandler.Initialize(this);
            _multiplayerSectionHandler.Initialize(this);
            _playersSectionHandler.Initialize(this);
            _worldSelectionSectionHandler.Initialize(this);
        }

        private void RegisterStates()
        {
            _stateMachine.RegisterState(
                (int)MainMenuStateType.Initial,
                new InitialState(_stateMachine)
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
