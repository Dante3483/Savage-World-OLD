using System;
using SavageWorld.Runtime.World.Generation;
using UnityEngine;

namespace SavageWorld.Runtime.Session.Info
{
    [Serializable]
    public class WorldInfo
    {
        #region Fields
        //TODO: Split info in different classes (WorldSizeConfig, WorldGenerationConfig, etc)
        [SerializeField]
        private WorldConfig _config;

        [SerializeField]
        private string _name;

        [SerializeField]
        private int _seed;

        [SerializeField]
        private int _width;

        [SerializeField]
        private int _height;
        #endregion

        #region Properties
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public int Seed
        {
            get => _seed;
            set => _seed = value;
        }
        public int Width
        {
            get => _width;
            set => _width = value;
        }
        public int Height
        {
            get => _height;
            set => _height = value;
        }
        public WorldConfig Config
        {
            get => _config;
            set => _config = value;
        }
        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
