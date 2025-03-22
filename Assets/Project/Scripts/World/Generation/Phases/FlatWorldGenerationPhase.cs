using System.Threading.Tasks;
using SavageWorld.Runtime.World.Elements;

namespace SavageWorld.Runtime.World.Generation.Phases
{
    public class FlatWorldGenerationPhase : WorldGenerationPhase
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods
        protected override void Run()
        {
            var layers = _info.Layers;
            foreach (var layer in layers)
            {
                Parallel.For(0, _info.Width, (x) => CreateLayer(x, layer));
            }
        }

        private void CreateLayer(int x, Layer layer)
        {
            var start = layer.Start;
            var end = layer.End;
            var defaultBlock = layer.DefaultBlock;
            var defaultWall = layer.DefaultWall;
            for (int y = start; y <= end; y++)
            {
                SetBlockData(x, y, defaultBlock);
                SetWallData(x, y, defaultWall);
            }
        }
        #endregion
    }
}
