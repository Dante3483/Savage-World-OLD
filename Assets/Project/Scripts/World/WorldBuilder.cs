using System;
using SavageWorld.Runtime.Core;
using SavageWorld.Runtime.Session.Info;

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
        public void GenerateWorld()
        {
            var worldInfo = new WorldInfo();
            worldInfo.Seed = new Random().Next(int.MinValue, int.MaxValue);
            GameManager.Instance.CurrentSession.WorldInfo = worldInfo;
        }

        public void LoadWorld() { }
        #endregion

        #region Private Methods

        #endregion
    }
}
