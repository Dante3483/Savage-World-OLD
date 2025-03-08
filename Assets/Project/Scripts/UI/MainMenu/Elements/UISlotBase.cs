using System;
using UnityEngine;
using UnityEngine.UI;

namespace SavageWorld.Runtime.UI.MainMenu.Elements
{
    public class UISlotBase : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private Button _selectBtn;

        [SerializeField]
        private Button _removeBtn;

        [SerializeField]
        private Button _pinBtn;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates
        public event Action<UISlotBase> SelectBtnClicked;
        public event Action<UISlotBase> RemoveBtnClicked;
        public event Action<UISlotBase> PinBtnClicked;
        #endregion

        #region Monobehaviour Methods
        private void OnEnable()
        {
            _selectBtn.onClick.AddListener(OnSelectBtnClicked);
            _removeBtn.onClick.AddListener(OnRemoveBtnClicked);
            _pinBtn.onClick.AddListener(OnPinBtnClicked);
        }

        private void OnDisable()
        {
            _selectBtn.onClick.RemoveListener(OnSelectBtnClicked);
            _removeBtn.onClick.RemoveListener(OnRemoveBtnClicked);
            _pinBtn.onClick.RemoveListener(OnPinBtnClicked);
        }
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods
        private void OnSelectBtnClicked()
        {
            SelectBtnClicked?.Invoke(this);
        }

        private void OnRemoveBtnClicked()
        {
            RemoveBtnClicked?.Invoke(this);
        }

        private void OnPinBtnClicked()
        {
            PinBtnClicked?.Invoke(this);
        }
        #endregion
    }
}
