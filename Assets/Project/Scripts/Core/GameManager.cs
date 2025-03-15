using SavageWorld.Runtime.Core.States;
using SavageWorld.Runtime.Enums.StateMachine;
using SavageWorld.Runtime.Session;
using SavageWorld.Runtime.Utilities.Singleton;
using SavageWorld.Runtime.Utilities.StateMachine;
using SavageWorld.Runtime.World;
using SavageWorld.Runtime.World.Generation;
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

        //REMOVE
        [SerializeField]
        private WorldConfig _worldConfig;
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
        public WorldConfig WorldConfig
        {
            get => _worldConfig;
            set => _worldConfig = value;
        }
        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods
        private void Start()
        {
            RegisterStates();
            ChangeState(GameStateType.Initialization);
        }
        #endregion

        #region Public Methods
        public void ChangeState(GameStateType newState)
        {
            _stateMachine.ChangeState((int)newState);
        }
        #endregion

        #region Private Methods
        private void RegisterStates()
        {
            _stateMachine.RegisterState(
                (int)GameStateType.Initialization,
                new InitializationState(_stateMachine)
            );
            _stateMachine.RegisterState(
                (int)GameStateType.MainMenu,
                new MainMenuState(_stateMachine)
            );
            _stateMachine.RegisterState(
                (int)GameStateType.WorldCreation,
                new WorldCreationState(_stateMachine)
            );
            _stateMachine.RegisterState(
                (int)GameStateType.Gameplay,
                new GameplayState(_stateMachine)
            );
        }
        #endregion
    }
}
