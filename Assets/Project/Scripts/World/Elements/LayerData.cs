using System.Collections.Generic;
using SavageWorld.Runtime.Enums.World;
using UnityEngine;

namespace SavageWorld.Runtime.World.Elements
{
    [CreateAssetMenu(fileName = "NewLayerData", menuName = "World/Layer data")]
    public class LayerData : ScriptableObject
    {
        #region Fields
        [SerializeField]
        private Layers _layer;

        [SerializeField]
        private List<int> _test;
        #endregion

        #region Properties

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
