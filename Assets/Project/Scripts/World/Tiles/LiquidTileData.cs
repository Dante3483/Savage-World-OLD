using SavageWorld.Runtime.Enums.World;
using UnityEngine;

namespace SavageWorld.Runtime.World.Tiles
{
    [CreateAssetMenu(fileName = "NewLiquidTileData", menuName = "World/Tiles/Liquid")]
    public class LiquidTileData : TileDataBase<LiquidTileId>
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
            return TileType.Liquid;
        }
        #endregion
    }
}
