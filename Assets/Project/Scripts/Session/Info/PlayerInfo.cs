using System;
using UnityEngine;

namespace SavageWorld.Runtime.Session.Info
{
    [Serializable]
    public class PlayerInfo
    {
        #region Fields
        [SerializeField]
        private string _name;
        #endregion

        #region Properties
        public string Name
        {
            get => _name;
            set => _name = value;
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
