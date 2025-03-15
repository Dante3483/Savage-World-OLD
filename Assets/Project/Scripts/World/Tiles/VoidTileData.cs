using SavageWorld.Runtime.Enums.World;
using UnityEngine;

namespace SavageWorld.Runtime.World.Tiles
{
    [CreateAssetMenu(fileName = "NewAmbientTileData", menuName = "World/Tiles/Void")]
    public class VoidTileData : TileDataBase<VoidTileId>
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods
        protected override TileType GetDefaultType()
        {
            return TileType.Void;
        }
        #endregion
    }
}
