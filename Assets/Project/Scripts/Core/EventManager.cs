using System;

namespace SavageWorld.Runtime.Core
{
    public static class EventManager
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Events / Delegates
        public static event Action<int, int> BlockDataChanged;
        public static event Action<int, int> WallDataChanged;
        #endregion

        #region Public Methods
        public static void OnBlockDataChanged(int x, int y) => BlockDataChanged?.Invoke(x, y);

        public static void OnWallDataChanged(int x, int y) => WallDataChanged?.Invoke(x, y);
        #endregion

        #region Private Methods

        #endregion
    }
}
