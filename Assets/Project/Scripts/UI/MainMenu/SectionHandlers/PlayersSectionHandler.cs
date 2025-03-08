using System;
using UnityEngine;
using UnityEngine.UI;

namespace SavageWorld.Runtime.UI.MainMenu.SectionHandlers
{
    [Serializable]
    public class PlayersSectionHandler : SectionHandlerBase
    {
        #region Fields
        [SerializeField]
        private Button _createBtn;

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
            _createBtn.onClick.AddListener(OnCreateBtnClick);
            _backBtn.onClick.AddListener(OnBackBtnClick);
        }

        public override void RemoveListeners()
        {
            _createBtn.onClick.RemoveListener(OnCreateBtnClick);
            _backBtn.onClick.RemoveListener(OnBackBtnClick);
        }
        #endregion

        #region Private Methods
        private void OnCreateBtnClick()
        {
            Debug.Log("NEED IMPLEMENT PLAYER CREATION");
        }

        private void OnBackBtnClick()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
