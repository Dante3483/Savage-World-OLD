using System;
using SavageWorld.Runtime.Enums.StateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace SavageWorld.Runtime.UI.MainMenu.SectionHandlers
{
    [Serializable]
    public class MultiplayerSectionHandler : SectionHandlerBase
    {
        #region Fields
        [SerializeField]
        private Button _connectViaIPBtn;

        [SerializeField]
        private Button _hostAndPlayBtn;

        [SerializeField]
        private Button _backBtn;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public override void AddListeners()
        {
            RemoveListeners();
            _connectViaIPBtn.onClick.AddListener(OnConnectViaIPBtnClicked);
            _hostAndPlayBtn.onClick.AddListener(OnHostAndPlayBtnClicked);
            _backBtn.onClick.AddListener(OnBackBtnClicked);
        }

        public override void RemoveListeners()
        {
            _connectViaIPBtn.onClick.RemoveListener(OnConnectViaIPBtnClicked);
            _hostAndPlayBtn.onClick.RemoveListener(OnHostAndPlayBtnClicked);
            _backBtn.onClick.RemoveListener(OnBackBtnClicked);
        }
        #endregion

        #region Private Methods
        private void OnConnectViaIPBtnClicked()
        {
            _mainMenuManager.ChangeState(MainMenuStateType.ConnectViaIP);
        }

        private void OnHostAndPlayBtnClicked()
        {
            _mainMenuManager.ChangeState(MainMenuStateType.PlayerSelection);
        }

        private void OnBackBtnClicked()
        {
            _mainMenuManager.GoBack();
        }
        #endregion
    }
}
