using System.Collections.Generic;
using SavageWorld.Runtime.World.Generation.Phases;

namespace SavageWorld.Runtime.World.Generation.Creators
{
    public abstract class WorldCreatorBase
    {
        #region Fields
        private List<IWorldGenerationPhase> _phases = new();
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public WorldCreatorBase() { }
        #endregion

        #region Private Methods

        #endregion
    }
}
