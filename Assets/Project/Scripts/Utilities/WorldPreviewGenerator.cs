using System.IO;
using System.Threading.Tasks;
using SavageWorld.Runtime.Enums.World;
using SavageWorld.Runtime.World;
using UnityEngine;

namespace SavageWorld.Runtime.Utilities
{
    public static class WorldPreviewGenerator
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public static void ToTexture(this Tile[,] grid)
        {
            var texture = new Texture2D(grid.GetLength(0), grid.GetLength(1));
            var colors = new Color[grid.GetLength(0) * grid.GetLength(1)];
            Parallel.For(
                0,
                grid.GetLength(0),
                x =>
                {
                    for (int y = 0; y < grid.GetLength(1); y++)
                    {
                        colors[y * grid.GetLength(0) + x] = IdToColor(
                            grid[x, y].BlockType,
                            grid[x, y].BlockId
                        );
                    }
                }
            );
            texture.SetPixels(colors);
            texture.Apply();

            byte[] bytesMap = texture.EncodeToPNG();
            File.WriteAllBytes(Application.dataPath + "/WorldPreview.png", bytesMap);
        }
        #endregion

        #region Private Methods
        private static Color IdToColor(TileType type, ushort id)
        {
            switch (type)
            {
                case TileType.Void:
                    return GetVoidColor((VoidTileId)id);
                case TileType.Solid:
                    return GetSolidColor((SolidTileId)id);

                default:
                    break;
            }
            return Color.black;
        }

        private static Color GetVoidColor(VoidTileId id)
        {
            switch (id)
            {
                case VoidTileId.Air:
                    return RGBToColor(135, 210, 255);
                default:
                    break;
            }
            return Color.black;
        }

        private static Color GetSolidColor(SolidTileId id)
        {
            switch (id)
            {
                case SolidTileId.Dirt:
                    return RGBToColor(102, 51, 0);
                case SolidTileId.OceanGrass:
                    break;
                case SolidTileId.DesertGrass:
                    break;
                case SolidTileId.SavannahGrass:
                    break;
                case SolidTileId.MeadowGrass:
                    break;
                case SolidTileId.ForestGrass:
                    break;
                case SolidTileId.SwampGrass:
                    break;
                case SolidTileId.ConiferousForestGrass:
                    break;
                case SolidTileId.Stone:
                    break;
                case SolidTileId.Clay:
                    break;
                case SolidTileId.IronOre:
                    break;
                case SolidTileId.CopperOre:
                    break;
                default:
                    break;
            }
            return Color.black;
        }

        private static Color RGBToColor(byte r, byte g, byte b)
        {
            return new Color(r / 255f, g / 255f, b / 255f);
        }
        #endregion
    }
}
