using SavageWorld.Runtime.Enums.World;
using UnityEngine;

namespace SavageWorld.Runtime.World.Tiles
{
    public abstract class TileData : ScriptableObject
    {
        #region Fields
        [SerializeField]
        private TileType _type;
        private ushort _idNumber;
        #endregion

        #region Properties
        public TileType Type
        {
            get => _type;
        }
        public ushort Id
        {
            get => _idNumber;
        }
        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods

        #endregion

        #region Public Methods
        public TileData()
        {
            _type = SetType();
            _idNumber = SetId();
        }
        #endregion

        #region Private Methods
        protected abstract TileType SetType();

        protected abstract ushort SetId();
        #endregion
    }
}
