using System;
using System.Collections.Generic;
using System.Linq;
using SavageWorld.Runtime.Enums.World;
using SavageWorld.Runtime.World.Elements;
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

        [SerializeField]
        private List<Layer> _layers;
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
            set
            {
                _config = value;
                ParseConfig();
            }
        }
        public List<Layer> Layers
        {
            get => _layers;
        }
        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods
        private void ParseConfig()
        {
            _layers.Clear();
            var height = _config.Layers.Sum(layer => layer.Value.Height);
            _config.Layers.Aggregate(height, ParseLayer);
        }

        private int ParseLayer(int height, KeyValuePair<LayerType, LayerData> layer)
        {
            var startHeight = height - layer.Value.Height;
            var endHeight = height - 1;
            _layers.Add(
                new()
                {
                    Type = layer.Key,
                    Start = startHeight,
                    End = endHeight,
                    DefaultBlock = layer.Value.DefaultBlock,
                    DefaultWall = layer.Value.DefaultWall,
                }
            );
            return startHeight;
        }
        #endregion
    }
}
