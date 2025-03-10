using SavageWorld.Runtime.UI.Stores;
using SavageWorld.Runtime.Utilities.Singleton;
using UnityEngine;

namespace SavageWorld.Runtime.UI
{
    public class UIManager : Singleton<UIManager>
    {
        #region Fields
        [SerializeField]
        private MainMenuStore _mainMenuStore;
        #endregion

        #region Properties
        public MainMenuStore MainMenuStore
        {
            get => _mainMenuStore;
            set => _mainMenuStore = value;
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
