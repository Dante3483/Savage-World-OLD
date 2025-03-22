using System.Threading.Tasks;
using SavageWorld.Runtime.Core;
using SavageWorld.Runtime.Utilities;
using SavageWorld.Runtime.Utilities.Singleton;
using SavageWorld.Runtime.World.Tiles;
using UnityEngine;

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
            var worldInfo = GameManager.Instance.CurrentSession.WorldInfo;
            _width = worldInfo.Width;
            _height = worldInfo.Height;
            _grid = new Tile[_width, _height];
            Parallel.For(0, _width, InitializeColumn);
        }

        public void SetBlockData(int x, int y, TileData data)
        {
            if (!IsWithinBounds(x, y))
            {
                return;
            }
            if (data == null)
            {
                return;
            }
            _grid[x, y].SetBlockData(data);
            EventManager.OnBlockDataChanged(x, y);
        }

        public void SetWallData(int x, int y, TileData data)
        {
            if (!IsWithinBounds(x, y))
            {
                return;
            }
            if (data == null)
            {
                return;
            }
            _grid[x, y].SetWallData(data);
            EventManager.OnWallDataChanged(x, y);
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

        private bool IsWithinBounds(int x, int y)
        {
            return x >= 0 && x < _width && y >= 0 && y < _height;
        }

        [ContextMenu("Generate preview")]
        private void GeneratePreview()
        {
            _grid.ToTexture();
        }
        #endregion
    }
}
