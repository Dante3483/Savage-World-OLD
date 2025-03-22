using System;
using UnityEngine;

namespace SavageWorld.Runtime.World.Tiles
{
    public abstract class TileDataWithGenericId<TId> : TileData
        where TId : Enum
    {
        #region Fields
        [SerializeField]
        private TId _id;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods

        #endregion

        #region Public Methods
        protected override ushort SetId()
        {
            return Convert.ToUInt16(_id);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
