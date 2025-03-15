using System;
using SavageWorld.Runtime.Enums.StateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace SavageWorld.Runtime.UI.MainMenu.SectionHandlers
{
    [Serializable]
    public class InitialSectionHandler : SectionHandlerBase
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
            RemoveListeners();
            _singlePlayerBtn.onClick.AddListener(OnSinglePlayerBtnClicked);
            _multiplayerBtn.onClick.AddListener(OnMultiplayerBtnClicked);
            _settingsBtn.onClick.AddListener(OnSettingsBtnClicked);
            _exitBtn.onClick.AddListener(OnExitBtnClicked);
        }

        public override void RemoveListeners()
        {
            _singlePlayerBtn.onClick.RemoveListener(OnSinglePlayerBtnClicked);
            _multiplayerBtn.onClick.RemoveListener(OnMultiplayerBtnClicked);
            _settingsBtn.onClick.RemoveListener(OnSettingsBtnClicked);
            _exitBtn.onClick.RemoveListener(OnExitBtnClicked);
        }
        #endregion

        #region Private Methods
        private void OnSinglePlayerBtnClicked()
        {
            _mainMenuManager.ChangeState(MainMenuStateType.PlayerSelection);
        }

        private void OnMultiplayerBtnClicked()
        {
            _mainMenuManager.ChangeState(MainMenuStateType.NetworkSettings);
        }

        private void OnSettingsBtnClicked()
        {
            _mainMenuManager.ChangeState(MainMenuStateType.Settings);
        }

        private void OnExitBtnClicked()
        {
            Application.Quit();
        }
        #endregion
    }
}
