using SavageWorld.Runtime.Session;
using SavageWorld.Runtime.Utilities.Singleton;
using UnityEngine;

namespace SavageWorld.Runtime.Core
{
    public class GameManager : Singleton<GameManager>
    {
        #region Fields
        [SerializeField]
        private GameSession _currentGameSession;
        #endregion

        #region Properties
        public GameSession CurrentGameSession
        {
            get => _currentGameSession;
            set => _currentGameSession = value;
        }
        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
