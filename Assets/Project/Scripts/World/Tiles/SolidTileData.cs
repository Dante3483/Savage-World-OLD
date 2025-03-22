using SavageWorld.Runtime.Enums.World;
using UnityEngine;

namespace SavageWorld.Runtime.World.Tiles
{
    [CreateAssetMenu(fileName = "NewSolidTileData", menuName = "World/Tiles/Solid")]
    public class SolidTileData : TileDataWithGenericId<SolidTileId>
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
            return TileType.Solid;
        }
        #endregion
    }
}
