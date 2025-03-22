using System;
using SavageWorld.Runtime.Core;
using SavageWorld.Runtime.Enums.StateMachine;
using SavageWorld.Runtime.UI.MainMenu.Elements;
using UnityEngine;

namespace SavageWorld.Runtime.UI.MainMenu.SectionHandlers
{
    [Serializable]
    public class PlayersSectionHandler : SlotsSectionHandler<UIPlayerSlot>
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public override void CreateSlot(object slotData)
        {
            var newSlot = GameObject.Instantiate(_slotPrefab, _slotsContainer);
            newSlot.SetData(null, "Player Name", "Player Stats");
            newSlot.SelectBtnClicked += SlotSelectBtnClickedHandler;
            newSlot.RemoveBtnClicked += SlotRemoveBtnClickedHandler;
            newSlot.PinBtnClicked += SlotPinBtnClickedHandler;
            _slots.Add(newSlot);
        }
        #endregion

        #region Private Methods
        protected override void OnCreateBtnClicked()
        {
            CreateSlot(null);
        }

        protected override void SlotPinBtnClickedHandler(UISlot slot)
        {
            Debug.Log("NEED IMPLEMENT SLOT PIN");
        }

        protected override void SlotRemoveBtnClickedHandler(UISlot slot)
        {
            GameObject.Destroy(slot.gameObject);
            _slots.Remove(slot);
        }

        protected override void SlotSelectBtnClickedHandler(UISlot slot)
        {
            var playerSlot = slot as UIPlayerSlot;
            GameManager.Instance.CurrentSession.PlayerInfo.Name = playerSlot.Name;
            _mainMenuManager.ChangeState(MainMenuStateType.WorldSelection);
        }
        #endregion
    }
}
