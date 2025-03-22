using System.Collections.Generic;
using SavageWorld.Runtime.UI.MainMenu.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace SavageWorld.Runtime.UI.MainMenu.SectionHandlers
{
    public abstract class SlotsSectionHandler<TPrefabValue> : SectionHandler
        where TPrefabValue : UISlot
    {
        #region Fields
        protected List<UISlot> _slots = new();

        [SerializeField]
        protected TPrefabValue _slotPrefab;

        [SerializeField]
        protected RectTransform _slotsContainer;

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
        public override void Initialize(MainMenuManager mainMenuManager)
        {
            base.Initialize(mainMenuManager);
            //REMOVE
            for (int i = 0; i < 10; i++)
            {
                CreateSlot(null);
            }
        }

        public override void AddListeners()
        {
            RemoveListeners();
            _createBtn.onClick.AddListener(OnCreateBtnClicked);
            _backBtn.onClick.AddListener(OnBackBtnClicked);
            foreach (var slot in _slots)
            {
                slot.SelectBtnClicked += SlotSelectBtnClickedHandler;
                slot.RemoveBtnClicked += SlotRemoveBtnClickedHandler;
                slot.PinBtnClicked += SlotPinBtnClickedHandler;
            }
        }

        public override void RemoveListeners()
        {
            _createBtn.onClick.RemoveListener(OnCreateBtnClicked);
            _backBtn.onClick.RemoveListener(OnBackBtnClicked);
            foreach (var slot in _slots)
            {
                slot.SelectBtnClicked -= SlotSelectBtnClickedHandler;
                slot.RemoveBtnClicked -= SlotRemoveBtnClickedHandler;
                slot.PinBtnClicked -= SlotPinBtnClickedHandler;
            }
        }

        public abstract void CreateSlot(object slotData);
        #endregion

        #region Private Methods
        private void OnBackBtnClicked()
        {
            _mainMenuManager.GoBack();
        }

        protected abstract void OnCreateBtnClicked();

        protected abstract void SlotSelectBtnClickedHandler(UISlot slot);

        protected abstract void SlotRemoveBtnClickedHandler(UISlot slot);

        protected abstract void SlotPinBtnClickedHandler(UISlot slot);
        #endregion
    }
}
