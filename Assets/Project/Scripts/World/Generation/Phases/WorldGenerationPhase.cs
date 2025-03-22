using SavageWorld.Runtime.Session.Info;
using SavageWorld.Runtime.World.Tiles;

namespace SavageWorld.Runtime.World.Generation.Phases
{
    public abstract class WorldGenerationPhase : IWorldGenerationPhase
    {
        #region Fields
        protected TilesManager _tilesManager;
        protected WorldInfo _info;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public void Start(WorldInfo info)
        {
            _tilesManager = TilesManager.Instance;
            _info = info;
            Run();
        }
        #endregion

        #region Private Methods
        protected abstract void Run();

        protected void SetBlockData(int x, int y, TileData data)
        {
            _tilesManager.SetBlockData(x, y, data);
        }

        protected void SetWallData(int x, int y, TileData data)
        {
            _tilesManager.SetWallData(x, y, data);
        }
        #endregion
    }
}
