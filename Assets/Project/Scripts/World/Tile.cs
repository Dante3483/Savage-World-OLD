using System.Runtime.InteropServices;

namespace SavageWorld.Runtime.World
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Tile
    {
        #region Fields
        public ushort BlockId;
        public ushort WallId;
        public byte LiquidId;

        //public TileTypes BlockType;
        public float FlowValue;
        public byte ColliderIndex;

        /// <summary>
        /// <br>First 4 bits of SpriteId = BlockSpriteId</br>
        /// <br>Last 4 bits of SpriteId = WallSpriteId</br>
        /// </summary>
        public byte SpriteId;

        /// <summary>
        /// <br>0 bit of Flags = is unbreakable</br>
        /// <br>1 bit of Flags = is occupied</br>
        /// <br>2 bit of Flags = is tree</br>
        /// <br>3 bit of Flags = is tree trunk</br>
        /// <br>4 bit of Flags = is collider horizontal flipped</br>
        /// <br>5 bit of Flags = is liquid settled</br>
        /// <br>5 bit of Flags = is waterfall</br>
        /// </summary>
        public byte Flags;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public static Tile GetEmpty()
        {
            return new()
            {
                BlockId = 0,
                WallId = 0,
                SpriteId = 0,
                //BlockType = TileTypes.Abstract,
                Flags = 0,
                ColliderIndex = byte.MaxValue,
                LiquidId = byte.MaxValue,
                FlowValue = 0,
            };
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
