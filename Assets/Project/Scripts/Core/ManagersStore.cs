using System;
using SavageWorld.Runtime.UI.MainMenu;
using UnityEngine;

namespace SavageWorld.Runtime.Core
{
    [Serializable]
    public class ManagersStore
    {
        #region Fields
        [SerializeField]
        private MainMenuManager _mainMenuManager;
        #endregion

        #region Properties
        public MainMenuManager MainMenuManager
        {
            get => _mainMenuManager;
            set => _mainMenuManager = value;
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
