using System;
using SavageWorld.Runtime.Enums.World;
using UnityEngine;

namespace SavageWorld.Runtime.World.Tiles
{
    public abstract class TileDataBase<TId> : ScriptableObject
        where TId : Enum
    {
        #region Fields
        [SerializeField]
        private TId _id;

        [SerializeField]
        private TileType _type;
        #endregion

        #region Properties
        public TileType Type
        {
            get => _type;
            set => _type = value;
        }
        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods

        #endregion

        #region Public Methods
        public TileDataBase()
        {
            _type = GetDefaultType();
        }

        public ushort GetId()
        {
            return Convert.ToUInt16(_id);
        }
        #endregion

        #region Private Methods
        protected abstract TileType GetDefaultType();
        #endregion
    }
}
