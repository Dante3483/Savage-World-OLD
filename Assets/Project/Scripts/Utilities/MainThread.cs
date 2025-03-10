using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using SavageWorld.Runtime.Utilities.Singleton;
using UnityEngine;

namespace SavageWorld.Runtime.Utilities
{
    public class MainThread : Singleton<MainThread>
    {
        #region Fields
        [SerializeField]
        private int _maxActionsPerUpdate = 20;
        private ConcurrentQueue<(Action action, TaskCompletionSource<bool> tcs)> _actions = new();
        private Thread _mainThread;
        #endregion

        #region Properties

        #endregion

        #region Events / Delegates

        #endregion

        #region Monobehaviour Methods
        protected override void Awake()
        {
            base.Awake();
            _mainThread = Thread.CurrentThread;
        }

        private void Update()
        {
            int actionsProcessed = 0;
            while (actionsProcessed < _maxActionsPerUpdate)
            {
                if (!_actions.TryDequeue(out var actionPair))
                {
                    break;
                }
                actionPair.action?.Invoke();
                actionPair.tcs?.SetResult(true);
                actionsProcessed++;
            }
        }
        #endregion

        #region Public Methods
        public void Execute(Action action)
        {
            if (!TryExecute(action))
            {
                _actions.Enqueue((action, null));
            }
        }

        public void ExecuteAndWait(Action action)
        {
            if (!TryExecute(action))
            {
                var tcs = new TaskCompletionSource<bool>();
                _actions.Enqueue((action, tcs));
                tcs.Task.Wait();
            }
        }
        #endregion

        #region Private Methods
        private bool TryExecute(Action action)
        {
            if (IsMainThread())
            {
                action?.Invoke();
                return true;
            }
            return false;
        }

        private bool IsMainThread()
        {
            return _mainThread.Equals(Thread.CurrentThread);
        }
        #endregion
    }
}
