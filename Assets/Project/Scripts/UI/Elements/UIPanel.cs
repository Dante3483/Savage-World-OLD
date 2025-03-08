using UnityEngine;

namespace SavageWorld.Runtime.UI.Elements
{
    [RequireComponent(typeof(RectTransform))]
    public class UIPanel : MonoBehaviour
    {
        #region Fields
        private RectTransform _content;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods
        private void Awake()
        {
            _content = transform.Find("Content") as RectTransform;
            if (_content == null)
            {
                Debug.LogError($"UIPanel {name}: Content not found.");
                Reset();
            }
            Hide();
        }

        private void Reset()
        {
            _content = transform.Find("Content") as RectTransform;
            if (_content == null)
            {
                var newContent = new GameObject("Content");
                newContent.transform.SetParent(transform);
                _content = newContent.AddComponent<RectTransform>();
            }
        }
        #endregion

        #region Public Methods
        public void Show()
        {
            _content.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _content.gameObject.SetActive(false);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
