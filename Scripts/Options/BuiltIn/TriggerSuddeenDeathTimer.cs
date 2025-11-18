using BepInEx.Configuration;
using HarmonyLib;
using System;
using System.Linq;
using UnboundLib;
using UnboundLib.Utils.UI;
using UnityEngine;

namespace MoreSuddenDeathOptions.Options.BuiltIn {
    public class TriggerSuddeenDeathTimer : SuddenDeathOption {
        public override string Name => "Trigger With Timer";

        public float TriggerWhenNTimePass = 30;
        public bool Enable = false;

        internal ConfigEntry<float> TriggerWhenNTimePassConfig;
        internal ConfigEntry<bool> EnableConfig;

        private float LastSetTime = 0;
        
        public TriggerSuddeenDeathTimer() {
            EnableConfig = MoreSuddenDeathOptions.ModConfig.Bind<bool>(MoreSuddenDeathOptions.ModName.Sanitize(), $"{Name.Sanitize()}_Enable", false, $"Enable or disable \"{Name}\" sudden death option");
            Enable = EnableConfig.Value;

            TriggerWhenNTimePassConfig = MoreSuddenDeathOptions.ModConfig.Bind<float>(MoreSuddenDeathOptions.ModName.Sanitize(), nameof(TriggerWhenNTimePass), TriggerWhenNTimePass, "The amount of time require for sudden death to trigger");
            TriggerWhenNTimePass = TriggerWhenNTimePassConfig.Value;
        }

        public override bool ActivateSuddenDeath() {
            return Enable && Time.time > LastSetTime + TriggerWhenNTimePass;
        }

        public override void OnReset() {
            LastSetTime = Time.time;
        }

        public override void SetDataToSync() {
            SyncedFloatData[nameof(TriggerWhenNTimePass)] = TriggerWhenNTimePassConfig.Value;
            SyncedIntData[$"{Name.Sanitize()}_Enable"] = Enable ? 1 : 0;
        }

        public override void ReadSyncedData() {
            TriggerWhenNTimePass = SyncedIntData[nameof(TriggerWhenNTimePass)];
            Enable = SyncedIntData[$"{Name.Sanitize()}_Enable"] == 1;
        }
    }
}