using System;
using SavageWorld.Runtime.UI.Elements;
using UnityEngine;

namespace SavageWorld.Runtime.UI.Stores
{
    [Serializable]
    public class MainMenuStore : Store
    {
        #region Fields
        [SerializeField]
        private UIPanel _initialPanel;

        [SerializeField]
        private UIPanel _networkSettingsPanel;

        [SerializeField]
        private UIPanel _settingsPanel;

        [SerializeField]
        private UIPanel _playerSelectionPanel;

        [SerializeField]
        private UIPanel _worldSelectionPanel;

        [SerializeField]
        private UIPanel _connectViaIPPanel;

        [SerializeField]
        private UIPanel _hostAndPlayPanel;

        [SerializeField]
        private UIPanel _loadingPanel;

        [SerializeField]
        private UIProgressBar _loadingProgressBar;
        #endregion

        #region Properties
        public UIPanel InitialPanel
        {
            get => _initialPanel;
            set => _initialPanel = value;
        }
        public UIPanel NetworkSettingsPanel
        {
            get => _networkSettingsPanel;
            set => _networkSettingsPanel = value;
        }
        public UIPanel SettingsPanel
        {
            get => _settingsPanel;
            set => _settingsPanel = value;
        }
        public UIPanel PlayerSelectionPanel
        {
            get => _playerSelectionPanel;
            set => _playerSelectionPanel = value;
        }
        public UIPanel WorldSelectionPanel
        {
            get => _worldSelectionPanel;
            set => _worldSelectionPanel = value;
        }
        public UIPanel ConnectViaIPPanel
        {
            get => _connectViaIPPanel;
            set => _connectViaIPPanel = value;
        }
        public UIPanel HostAndPlayPanel
        {
            get => _hostAndPlayPanel;
            set => _hostAndPlayPanel = value;
        }
        public UIPanel LoadingPanel
        {
            get => _loadingPanel;
            set => _loadingPanel = value;
        }
        public UIProgressBar LoadingProgressBar
        {
            get => _loadingProgressBar;
            set => _loadingProgressBar = value;
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
