using SavageWorld.Runtime.Enums.World;
using SavageWorld.Runtime.Utilities.SerializableDictionary;
using SavageWorld.Runtime.World.Elements;
using UnityEngine;

namespace SavageWorld.Runtime.World.Generation.Configs
{
    [CreateAssetMenu(fileName = "NewCommonWorldConfig", menuName = "World/Configs/Common world")]
    public class CommonWorldConfig : ScriptableObject
    {
        #region Fields
        //TODO: Make it more generic to remove hardcode parts
        //Maybe use custome editor for this
        [Header("Statuses")]
        [SerializeField]
        private bool _disableAll;

        [SerializeField]
        private bool _enableAll;

        [SerializeField]
        private bool _flatWorldGeneration;

        [SerializeField]
        private bool _landscapeGeneration;

        [SerializeField]
        private bool _biomesGeneration;

        [SerializeField]
        private bool _clustersGeneration;

        [SerializeField]
        private bool _cavesGeneration;

        [SerializeField]
        private bool _starterCavesGeneration;

        [SerializeField]
        private bool _lakesGeneration;

        [SerializeField]
        private bool _oasisesGeneration;

        [SerializeField]
        private bool _grassSeeding;

        [SerializeField]
        private bool _plantsGeneration;

        [SerializeField]
        private bool _treesGeneration;

        [SerializeField]
        private bool _pickUpItemsGeneration;

        [SerializeField]
        private bool _setRandomTiles;

        [SerializeField]
        private bool _blockProcessing;

        [SerializeField]
        private bool _setPhysicsShapes;

        [Header("Other")]
        [SerializeField]
        private SerializableDictionary<Layers, LayerData> _layers;
        #endregion

        #region Properties
        public bool DisableAll
        {
            get => _disableAll;
            set => _disableAll = value;
        }
        public bool EnableAll
        {
            get => _enableAll;
            set => _enableAll = value;
        }
        public bool FlatWorldGeneration
        {
            get => _flatWorldGeneration;
            set => _flatWorldGeneration = value;
        }
        public bool LandscapeGeneration
        {
            get => _landscapeGeneration;
            set => _landscapeGeneration = value;
        }
        public bool BiomesGeneration
        {
            get => _biomesGeneration;
            set => _biomesGeneration = value;
        }
        public bool ClustersGeneration
        {
            get => _clustersGeneration;
            set => _clustersGeneration = value;
        }
        public bool CavesGeneration
        {
            get => _cavesGeneration;
            set => _cavesGeneration = value;
        }
        public bool StarterCavesGeneration
        {
            get => _starterCavesGeneration;
            set => _starterCavesGeneration = value;
        }
        public bool LakesGeneration
        {
            get => _lakesGeneration;
            set => _lakesGeneration = value;
        }
        public bool OasisesGeneration
        {
            get => _oasisesGeneration;
            set => _oasisesGeneration = value;
        }
        public bool GrassSeeding
        {
            get => _grassSeeding;
            set => _grassSeeding = value;
        }
        public bool PlantsGeneration
        {
            get => _plantsGeneration;
            set => _plantsGeneration = value;
        }
        public bool TreesGeneration
        {
            get => _treesGeneration;
            set => _treesGeneration = value;
        }
        public bool PickUpItemsGeneration
        {
            get => _pickUpItemsGeneration;
            set => _pickUpItemsGeneration = value;
        }
        public bool SetRandomTiles
        {
            get => _setRandomTiles;
            set => _setRandomTiles = value;
        }
        public bool BlockProcessing
        {
            get => _blockProcessing;
            set => _blockProcessing = value;
        }
        public bool SetPhysicsShapes
        {
            get => _setPhysicsShapes;
            set => _setPhysicsShapes = value;
        }
        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods
        private void OnValidate()
        {
            if (DisableAll)
            {
                DisableAll = false;
                DisableAllFlags();
            }
            if (EnableAll)
            {
                EnableAll = false;
                EnableAllFlags();
            }
        }
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods
        private void EnableAllFlags()
        {
            FlatWorldGeneration = true;
            LandscapeGeneration = true;
            BiomesGeneration = true;
            ClustersGeneration = true;
            CavesGeneration = true;
            StarterCavesGeneration = true;
            LakesGeneration = true;
            OasisesGeneration = true;
            GrassSeeding = true;
            PlantsGeneration = true;
            TreesGeneration = true;
            PickUpItemsGeneration = true;
            SetRandomTiles = true;
            BlockProcessing = true;
            SetPhysicsShapes = true;
        }

        private void DisableAllFlags()
        {
            FlatWorldGeneration = false;
            LandscapeGeneration = false;
            BiomesGeneration = false;
            ClustersGeneration = false;
            CavesGeneration = false;
            StarterCavesGeneration = false;
            LakesGeneration = false;
            OasisesGeneration = false;
            GrassSeeding = false;
            PlantsGeneration = false;
            TreesGeneration = false;
            PickUpItemsGeneration = false;
            SetRandomTiles = false;
            BlockProcessing = false;
            SetPhysicsShapes = false;
        }
        #endregion
    }
}
