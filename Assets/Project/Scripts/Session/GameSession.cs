using System;
using SavageWorld.Runtime.Session.Info;
using UnityEngine;

namespace SavageWorld.Runtime.Session
{
    [Serializable]
    public class GameSession
    {
        #region Fields
        [SerializeField]
        private PlayerInfo _playerInfo;

        [SerializeField]
        private WorldInfo _worldInfo;
        #endregion

        #region Properties
        public PlayerInfo PlayerInfo
        {
            get => _playerInfo;
            set => _playerInfo = value;
        }
        public WorldInfo WorldInfo
        {
            get => _worldInfo;
            set => _worldInfo = value;
        }
        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
