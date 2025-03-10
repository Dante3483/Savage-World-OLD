using System.Threading.Tasks;
using SavageWorld.Runtime.Core;
using SavageWorld.Runtime.Utilities.Singleton;

namespace SavageWorld.Runtime.World
{
    public class TilesManager : Singleton<TilesManager>
    {
        #region Fields
        private Tile[,] _grid;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods

        #endregion

        #region Public Methods
        public void Initialize()
        {
            //_setOfCollidersPositions = new();
            //TerrainConfigurationSO terrainConfiguration = _gameManager.TerrainConfiguration;
            //int terrainWidth = terrainConfiguration.TerrainWidth;
            //int terrainHeight = terrainConfiguration.TerrainHeight;
            var worldInfo = GameManager.Instance.CurrentSession.WorldInfo;
            var width = worldInfo.Width;
            var height = worldInfo.Height;
            _grid = new Tile[width, height];
            Tile emptyData = Tile.GetEmpty();
            //GameConsole.Log($"Size of world cell data: {Marshal.SizeOf(emptyData)}");
            Parallel.For(
                0,
                width,
                (index) =>
                {
                    int x = index;
                    for (int y = 0; y < height; y++)
                    {
                        _grid[x, y] = Tile.GetEmpty();
                    }
                }
            );
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
