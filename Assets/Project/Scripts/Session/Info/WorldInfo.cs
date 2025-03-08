using System;
using UnityEngine;

namespace SavageWorld.Runtime.Session.Info
{
    [Serializable]
    public class WorldInfo
    {
        #region Fields
        [SerializeField]
        private string _name;

        [SerializeField]
        private int _seed;

        [SerializeField]
        private int _currentWorldWidth;

        [SerializeField]
        private int _currentWorldHeight;
        #endregion

        #region Properties
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public int Seed
        {
            get => _seed;
            set => _seed = value;
        }
        public int CurrentWorldWidth
        {
            get => _currentWorldWidth;
            set => _currentWorldWidth = value;
        }
        public int CurrentWorldHeight
        {
            get => _currentWorldHeight;
            set => _currentWorldHeight = value;
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
