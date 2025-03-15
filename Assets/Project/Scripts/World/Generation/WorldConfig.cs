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
        private SerializableDictionary<WorldGenerationPhaseBase, bool> _phases;

        [SerializeField]
        private SerializableDictionary<LayerType, LayerData> _layers;
        #endregion

        #region Properties
        public SerializableDictionary<WorldGenerationPhaseBase, bool> Phases
        {
            get => _phases;
            set => _phases = value;
        }
        public SerializableDictionary<LayerType, LayerData> Layers
        {
            get => _layers;
            set => _layers = value;
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
