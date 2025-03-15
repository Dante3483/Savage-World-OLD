using System;
using System.Collections.Generic;
using UnityEngine;

namespace SavageWorld.Runtime.Utilities.SerializableDictionary
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue>
        : Dictionary<TKey, TValue>,
            ISerializationCallbackReceiver
    {
        #region Fields
        [SerializeField]
        private List<SerializableKeyValuePair<TKey, TValue>> _items = new();

        [SerializeField]
        private bool _isReadOnly;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public SerializableDictionary(bool isReadOnly = false)
        {
            _isReadOnly = isReadOnly;
        }

        public new void Add(TKey key, TValue value)
        {
            var valid = base.TryAdd(key, value);
            _items.Add(new(key, value, valid));
        }

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize()
        {
            Clear();
            for (int i = 0; i < _items.Count; i++)
            {
                var item = _items[i];
                var isValid = item.Key is null ? false : TryAdd(item.Key, item.Value);
                _items[i] = new(item.Key, item.Value, isValid);
            }
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
