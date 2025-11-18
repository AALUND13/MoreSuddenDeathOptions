using BepInEx.Configuration;
using HarmonyLib;
using MapEmbiggener;
using System.Linq;
using UnboundLib;

namespace MoreSuddenDeathOptions.Options.BuiltIn {
    public class TriggerSuddeenDeathPlayers : SuddenDeathOption {
        public override string Name => "Trigger With Amount Of Player";

        public int EnableWhenAboveNPlayers = 2;
        public int TriggerWhenBelowOrEqualNPlayers = 2;
        public bool Enable = false;

        internal ConfigEntry<int> EnableWhenAboveNPlayersConfig;
        internal ConfigEntry<int> TriggerWhenBelowOrEqualNPlayersConfig;
        public ConfigEntry<bool> EnableConfig;

        public TriggerSuddeenDeathPlayers() {
            bool suddenDeathEnable = MapEmbiggener.MapEmbiggener.SuddenDeathConfig.Value;

            EnableConfig = MoreSuddenDeathOptions.ModConfig.Bind<bool>(MoreSuddenDeathOptions.ModName.Sanitize(), $"{Name.Sanitize()}_Enable", suddenDeathEnable, $"Enable or disable \"{Name}\" sudden death option");
            Enable = EnableConfig.Value;

            EnableWhenAboveNPlayersConfig = MoreSuddenDeathOptions.ModConfig.Bind<int>(MoreSuddenDeathOptions.ModName.Sanitize(), nameof(EnableWhenAboveNPlayers), EnableWhenAboveNPlayers, "The amount of players needed for this sudden death option to be enable");
            EnableWhenAboveNPlayers = EnableWhenAboveNPlayersConfig.Value;

            TriggerWhenBelowOrEqualNPlayersConfig = MoreSuddenDeathOptions.ModConfig.Bind<int>(MoreSuddenDeathOptions.ModName.Sanitize(), nameof(TriggerWhenBelowOrEqualNPlayers), TriggerWhenBelowOrEqualNPlayers, "Trigger the sudden death once the the alive players is below or equal to this amount");
            TriggerWhenBelowOrEqualNPlayers = TriggerWhenBelowOrEqualNPlayersConfig.Value;
        }

        public override bool ActivateSuddenDeath() {
            if(Enable && PlayerManager.instance.players.Count > EnableWhenAboveNPlayers) {
                return PlayerManager.instance.players.Where(p => !p.data.dead).Count() <= TriggerWhenBelowOrEqualNPlayers;
            }
            return false;
        }

        public override void SetDataToSync() {
            SyncedIntData[nameof(EnableWhenAboveNPlayers)] = EnableWhenAboveNPlayersConfig.Value;
            SyncedIntData[nameof(TriggerWhenBelowOrEqualNPlayers)] = TriggerWhenBelowOrEqualNPlayersConfig.Value;
            SyncedIntData[$"{Name.Sanitize()}_Enable"] = Enable ? 1 : 0;
        }

        public override void ReadSyncedData() {
            EnableWhenAboveNPlayers = SyncedIntData[nameof(EnableWhenAboveNPlayers)];
            TriggerWhenBelowOrEqualNPlayers = SyncedIntData[nameof(TriggerWhenBelowOrEqualNPlayers)];
            Enable = SyncedIntData[$"{Name.Sanitize()}_Enable"] == 1;
        }
    }
}
