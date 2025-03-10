using System;
using UnityEngine;

namespace SavageWorld.Runtime.Utilities.SerializableDictionary
{
    [Serializable]
    public struct SerializableKeyValuePair<TKey, TValue>
    {
        #region Fields
        [SerializeField]
        [HideInInspector]
        private string _name;

        [SerializeField]
        [SerializeReference]
        private TKey _key;

        [SerializeField]
        [SerializeReference]
        private TValue _value;

        [SerializeField]
        private bool _isValid;

        #endregion

        #region Properties
        public TKey Key
        {
            get => _key;
        }
        public TValue Value
        {
            get => _value;
        }
        public bool IsValid
        {
            get => _isValid;
        }
        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public SerializableKeyValuePair(TKey key, TValue value, bool isValid)
        {
            _key = key;
            _value = value;
            _isValid = isValid;
            _name = key.ToString();
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
