using SavageWorld.Runtime.Enums.World;
using UnityEngine;

namespace SavageWorld.Runtime.World.Tiles
{
    [CreateAssetMenu(fileName = "NewPlantTileData", menuName = "World/Tiles/Plant")]
    public class PlantTileData : TileDataBase<PlantTileId>
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
            return TileType.Plant;
        }
        #endregion
    }
}
