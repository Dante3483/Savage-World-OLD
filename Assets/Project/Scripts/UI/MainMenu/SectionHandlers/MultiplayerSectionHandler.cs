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
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public override void AddListeners()
        {
            _connectViaIPBtn.onClick.AddListener(OnConnectViaIPButtonClicked);
            _hostAndPlayBtn.onClick.AddListener(OnHostAndPlayButtonClicked);
        }

        public override void RemoveListeners()
        {
            _connectViaIPBtn.onClick.RemoveListener(OnConnectViaIPButtonClicked);
            _hostAndPlayBtn.onClick.RemoveListener(OnHostAndPlayButtonClicked);
        }
        #endregion

        #region Private Methods
        private void OnConnectViaIPButtonClicked()
        {
            _mainMenuManager.ChangeState(MainMenuStateType.ConnectViaIP);
        }

        private void OnHostAndPlayButtonClicked()
        {
            _mainMenuManager.ChangeState(MainMenuStateType.PlayerSelection);
        }
        #endregion
    }
}
