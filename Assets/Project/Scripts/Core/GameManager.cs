using SavageWorld.Runtime.Core.States;
using SavageWorld.Runtime.Enums.StateMachine;
using SavageWorld.Runtime.Session;
using SavageWorld.Runtime.Utilities.Singleton;
using SavageWorld.Runtime.Utilities.StateMachine;
using SavageWorld.Runtime.World;
using UnityEngine;

namespace SavageWorld.Runtime.Core
{
    public class GameManager : Singleton<GameManager>
    {
        #region Fields
        [SerializeField]
        private ManagersStore _managersStore;

        [SerializeField]
        private GameSession _currentSession;
        private IStateMachine _stateMachine = new StateMachine();
        private WorldBuilder _worldBuilder = new();
        #endregion

        #region Properties
        public ManagersStore ManagersStore
        {
            get => _managersStore;
            set => _managersStore = value;
        }
        public GameSession CurrentSession
        {
            get => _currentSession;
            set => _currentSession = value;
        }
        public WorldBuilder WorldBuilder
        {
            get => _worldBuilder;
            set => _worldBuilder = value;
        }
        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods
        private void Start()
        {
            RegisterStates();
            ChangeState(GameStates.Initialization);
        }
        #endregion

        #region Public Methods
        public void ChangeState(GameStates newState)
        {
            _stateMachine.ChangeState((int)newState);
        }
        #endregion

        #region Private Methods
        private void RegisterStates()
        {
            _stateMachine.RegisterState(
                (int)GameStates.Initialization,
                new InitializationState(_stateMachine)
            );
            _stateMachine.RegisterState((int)GameStates.MainMenu, new MainMenuState(_stateMachine));
            _stateMachine.RegisterState(
                (int)GameStates.WorldCreation,
                new WorldCreationState(_stateMachine)
            );
        }
        #endregion
    }
}
