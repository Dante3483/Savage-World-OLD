using System;
using SavageWorld.Runtime.Core;
using SavageWorld.Runtime.Session.Info;
using SavageWorld.Runtime.World.Generation;

namespace SavageWorld.Runtime.World
{
    public class WorldBuilder
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public void GenerateWorld(WorldConfig config)
        {
            var worldInfo = new WorldInfo();
            worldInfo.Seed = new Random().Next(int.MinValue, int.MaxValue);
            worldInfo.Config = config;
            GameManager.Instance.CurrentSession.WorldInfo = worldInfo;
            var creator = new WorldCreator(worldInfo);
            creator.Generate();
        }

        public void LoadWorld() { }
        #endregion

        #region Private Methods

        #endregion
    }
}
