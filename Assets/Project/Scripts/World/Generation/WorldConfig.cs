using SavageWorld.Runtime.Enums.World;
using SavageWorld.Runtime.Utilities.SerializableDictionary;
using SavageWorld.Runtime.World.Elements;
using SavageWorld.Runtime.World.Generation.Phases;
using UnityEngine;

namespace SavageWorld.Runtime.World.Generation
{
    [CreateAssetMenu(fileName = "NewWorldConfig", menuName = "World/Config")]
    public class WorldConfig : ScriptableObject
    {
        #region Fields
        [SerializeField]
        private SerializableDictionary<WorldGenerationPhase, bool> _phases;

        [SerializeField]
        private SerializableDictionary<LayerType, LayerData> _layers;
        #endregion

        #region Properties
        public SerializableDictionary<WorldGenerationPhase, bool> Phases
        {
            get => _phases;
        }
        public SerializableDictionary<LayerType, LayerData> Layers
        {
            get => _layers;
        }
        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
