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
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize()
        {
            Clear();
            for (int i = 0; i < _items.Count; i++)
            {
                var item = _items[i];
                var isValid = TryAdd(item.Key, item.Value);
                _items[i] = new(item.Key, item.Value, isValid);
            }
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
