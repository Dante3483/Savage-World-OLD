using UnityEngine;
using UnityEngine.UI;

namespace SavageWorld.Runtime.UI.Elements
{
    public class UIProgressBar : MonoBehaviour
    {
        #region Fields
        private Slider _slider;

        [SerializeField]
        private float _value;
        private float _maxValue;
        #endregion

        #region Properties
        public float MaxValue
        {
            get => _maxValue;
        }
        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods
        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _maxValue = _slider.maxValue;
        }

        private void Update()
        {
            _slider.value = _value;
        }

        private void OnDisable()
        {
            ResetSlider();
        }
        #endregion

        #region Public Methods
        public void UpdateValue(float value)
        {
            _value = value;
        }

        public void IncreaseValue(float value)
        {
            UpdateValue(_value + value);
        }

        public void ResetSlider()
        {
            UpdateValue(0f);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
