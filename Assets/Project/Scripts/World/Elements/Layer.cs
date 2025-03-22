using System;
using SavageWorld.Runtime.Enums.World;
using SavageWorld.Runtime.World.Tiles;
using UnityEngine;

namespace SavageWorld.Runtime.World.Elements
{
    [Serializable]
    public class Layer
    {
        #region Fields
        [SerializeField]
        private LayerType _type;

        [SerializeField]
        private int _start;

        [SerializeField]
        private int _end;

        [SerializeField]
        private TileData _defaultBlock;

        [SerializeField]
        private TileData _defaultWall;
        #endregion

        #region Properties
        public LayerType Type
        {
            get => _type;
            set => _type = value;
        }
        public int Start
        {
            get => _start;
            set => _start = value;
        }
        public int End
        {
            get => _end;
            set => _end = value;
        }
        public TileData DefaultBlock
        {
            get => _defaultBlock;
            set => _defaultBlock = value;
        }
        public TileData DefaultWall
        {
            get => _defaultWall;
            set => _defaultWall = value;
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
