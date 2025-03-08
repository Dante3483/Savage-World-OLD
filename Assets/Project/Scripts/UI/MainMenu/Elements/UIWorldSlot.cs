using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SavageWorld.Runtime.UI.MainMenu.Elements
{
    public class UIWorldSlot : UISlotBase
    {
        #region Fields
        [SerializeField]
        private Image _avatarImage;

        [SerializeField]
        private TMP_Text _nameText;

        [SerializeField]
        private TMP_Text _statsText;
        #endregion

        #region Properties
        public string Name => _nameText.text;
        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods

        #endregion

        #region Public Methods
        public void SetData(Sprite avatar, string name, string stats)
        {
            //_avatarImage.sprite = avatar;
            _nameText.text = name;
            _statsText.text = stats;
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
