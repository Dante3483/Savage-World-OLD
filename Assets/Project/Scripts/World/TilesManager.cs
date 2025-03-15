using System.Diagnostics;
using System.Threading.Tasks;
using SavageWorld.Runtime.Core;
using SavageWorld.Runtime.Utilities.Singleton;
using Debug = UnityEngine.Debug;

namespace SavageWorld.Runtime.World
{
    public class TilesManager : Singleton<TilesManager>
    {
        #region Fields
        private Tile[,] _grid;
        private int _width;
        private int _height;
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
            var stopwatch = Stopwatch.StartNew();
            var worldInfo = GameManager.Instance.CurrentSession.WorldInfo;
            _width = worldInfo.Width;
            _height = worldInfo.Height;
            _grid = new Tile[_width, _height];
            Parallel.For(0, _width, InitializeColumn);
            stopwatch.Stop();
            Debug.Log($"Initialization {stopwatch.Elapsed}");
        }
        #endregion

        #region Private Methods
        private void InitializeColumn(int x)
        {
            for (int y = 0; y < _height; y++)
            {
                _grid[x, y] = Tile.GetEmpty();
            }
        }
        #endregion
    }
}
