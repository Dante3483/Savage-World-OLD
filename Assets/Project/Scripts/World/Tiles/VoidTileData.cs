using SavageWorld.Runtime.Enums.World;
using UnityEngine;

namespace SavageWorld.Runtime.World.Tiles
{
    [CreateAssetMenu(fileName = "NewAmbientTileData", menuName = "World/Tiles/Void")]
    public class VoidTileData : TileDataWithGenericId<VoidTileId>
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
            return TileType.Void;
        }
        #endregion
    }
}
