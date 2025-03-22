using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace SavageWorld.Runtime.Utilities
{
    public class MethodTimer
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Public Methods
        public static void MeasureAndLog(Action action, string methodName = "Method")
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            Debug.Log($"{methodName} executed in {stopwatch.ElapsedMilliseconds} ms");
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
