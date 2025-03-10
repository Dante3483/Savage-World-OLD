using System;
using UnityEngine;

namespace SavageWorld.Runtime.World.Generation.Phases
{
    [Serializable]
    public abstract class WorldGenerationPhaseBase : IWorldGenerationPhase
    {
        #region Fields
        [SerializeField]
        private bool _isActive;
        #endregion

        #region Properties
        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }
        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public abstract void Start();
        #endregion

        #region Private Methods

        #endregion
    }
}
