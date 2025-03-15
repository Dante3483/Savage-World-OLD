using SavageWorld.Runtime.Session.Info;
using SavageWorld.Runtime.UI;

namespace SavageWorld.Runtime.World.Generation
{
    public class WorldCreator
    {
        #region Fields
        private WorldInfo _info;
        private WorldConfig _config;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public WorldCreator(WorldInfo info)
        {
            _info = info;
            _config = _info.Config;
        }

        public void Generate()
        {
            var phases = _config.Phases;
            var progressBar = UIManager.Instance.MainMenuStore.LoadingProgressBar;
            var valuePerStep = progressBar.MaxValue / phases.Count;
            foreach (var phase in _config.Phases)
            {
                if (phase.Value)
                {
                    phase.Key.Start();
                    progressBar.IncreaseValue(valuePerStep);
                }
            }
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
