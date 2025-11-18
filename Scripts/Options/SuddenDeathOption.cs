using MapEmbiggener.Controllers;
using System.Collections.Generic;

namespace MoreSuddenDeathOptions.Options {
    public abstract class SuddenDeathOption {
        public Dictionary<string, int> SyncedIntData =>
            ControllerManager.BoundsControllers[ControllerManager.DefaultBoundsControllerID].SyncedIntData;
        public Dictionary<string, float> SyncedFloatData =>
            ControllerManager.BoundsControllers[ControllerManager.DefaultBoundsControllerID].SyncedFloatData;
        public Dictionary<string, string> SyncedStringData =>
            ControllerManager.BoundsControllers[ControllerManager.DefaultBoundsControllerID].SyncedStringData;

        public abstract string Name { get; }

        public virtual void SetDataToSync() { }
        public virtual void ReadSyncedData() { }

        public virtual void OnReset() { }

        public abstract bool ActivateSuddenDeath();
    }
}
