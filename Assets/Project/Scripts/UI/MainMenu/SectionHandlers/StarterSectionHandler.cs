using System;
using SavageWorld.Runtime.Enums.StateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace SavageWorld.Runtime.UI.MainMenu.SectionHandlers
{
    [Serializable]
    public class StarterSectionHandler : SectionHandlerBase
    {
        #region Fields
        [SerializeField]
        private Button _singlePlayerBtn;

        [SerializeField]
        private Button _multiplayerBtn;

        [SerializeField]
        private Button _settingsBtn;

        [SerializeField]
        private Button _exitBtn;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public override void AddListeners()
        {
            _singlePlayerBtn.onClick.AddListener(OnSinglePlayerButtonClicked);
            _multiplayerBtn.onClick.AddListener(OnMultiplayerButtonClicked);
            _settingsBtn.onClick.AddListener(OnSettingsButtonClicked);
            _exitBtn.onClick.AddListener(OnExitButtonClicked);
        }

        public override void RemoveListeners()
        {
            _singlePlayerBtn.onClick.RemoveListener(OnSinglePlayerButtonClicked);
            _multiplayerBtn.onClick.RemoveListener(OnMultiplayerButtonClicked);
            _settingsBtn.onClick.RemoveListener(OnSettingsButtonClicked);
            _exitBtn.onClick.RemoveListener(OnExitButtonClicked);
        }
        #endregion

        #region Private Methods
        private void OnSinglePlayerButtonClicked()
        {
            _mainMenuManager.ChangeState(MainMenuStateType.PlayerSelection);
        }

        private void OnMultiplayerButtonClicked()
        {
            _mainMenuManager.ChangeState(MainMenuStateType.NetworkSettings);
        }

        private void OnSettingsButtonClicked()
        {
            _mainMenuManager.ChangeState(MainMenuStateType.Settings);
        }

        private void OnExitButtonClicked()
        {
            Application.Quit();
        }
        #endregion
    }
}
