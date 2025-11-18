using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using MoreSuddenDeathOptions.Options;
using MoreSuddenDeathOptions.Options.BuiltIn;
using MoreSuddenDeathOptions.Options.Menus;
using MoreSuddenDeathOptions.Options.Menus.BuiltIn;
using UnboundLib;

namespace MoreSuddenDeathOptions {
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.mapembiggener", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin(ModId, ModName, "1.0.0")]
    [BepInProcess("Rounds.exe")]
    public class MoreSuddenDeathOptions : BaseUnityPlugin {
        internal const string ModId = "com.aalund13.rounds.more_sudden_death_options";
        internal const string ModName = "More Sudden Death Options";

        internal static ConfigFile ModConfig;

        private void Awake() {
            new Harmony(ModId).PatchAll();
            ModConfig = Config;


            SuddenDeathOptionsManager suddenDeathOptionManager = gameObject.AddComponent<SuddenDeathOptionsManager>();
            suddenDeathOptionManager.RegisterOption<TriggerSuddeenDeathPlayers>();
            suddenDeathOptionManager.RegisterOption<TriggerSuddeenDeathTimer>();

            SuddenDeathMenuManager suddenDeathMenuManager = gameObject.AddComponent<SuddenDeathMenuManager>();
            suddenDeathMenuManager.RegisterMenu<TriggerSuddeenDeathPlayers, TriggerSuddeenDeathPlayersMenu>();
            suddenDeathMenuManager.RegisterMenu<TriggerSuddeenDeathTimer, TriggerSuddeenDeathTimerMenu>();
        }

        private void Start() {
            Unbound.RegisterMenu(ModName, () => { }, SuddenDeathMenuManager.Instance.CreateAllMenus, null, false);
        }
    }
}