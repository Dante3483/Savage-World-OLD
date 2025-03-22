using System;
using SavageWorld.Runtime.Core;
using SavageWorld.Runtime.Enums.StateMachine;
using SavageWorld.Runtime.UI.MainMenu.Elements;
using UnityEngine;

namespace SavageWorld.Runtime.UI.MainMenu.SectionHandlers
{
    [Serializable]
    public class WorldsSectionHandler : SlotsSectionHandler<UIWorldSlot>
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
            newSlot.SetData(null, "World Name", "World Stats");
            newSlot.SelectBtnClicked += SlotSelectBtnClickedHandler;
            newSlot.RemoveBtnClicked += SlotRemoveBtnClickedHandler;
            newSlot.PinBtnClicked += SlotPinBtnClickedHandler;
            _slots.Add(newSlot);
        }
        #endregion

        #region Private Methods
        protected override void OnCreateBtnClicked()
        {
            GameManager.Instance.ChangeState(GameStateType.WorldCreation);
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
            var worldSlot = slot as UIWorldSlot;
            GameManager.Instance.CurrentSession.WorldInfo.Name = worldSlot.Name;
        }
        #endregion
    }
}
