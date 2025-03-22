using SavageWorld.Runtime.Enums.World;
using UnityEngine;

namespace SavageWorld.Runtime.World.Tiles
{
    [CreateAssetMenu(fileName = "NewWallTileData", menuName = "World/Tiles/Wall")]
    public class WallTileData : TileDataWithGenericId<WallTileId>
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
        protected override TileType SetType()
        {
            return TileType.Wall;
        }
        #endregion
    }
}
