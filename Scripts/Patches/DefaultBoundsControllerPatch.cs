using MoreSuddenDeathOptions.Options;
using MoreSuddenDeathOptions.Utils;
using HarmonyLib;
using MapEmbiggener.Controllers.Default;

namespace MoreSuddenDeathOptions.Patches {
    [HarmonyPatch(typeof(DefaultBoundsController))]
    internal class DefaultBoundsControllerPatch {
        [HarmonyPatch(nameof(DefaultBoundsController.SetDataToSync))]
        [HarmonyPostfix]
        public static void SetDataToSync() => SuddenDeathOptionsManager.Instance.SetDataToSync();

        [HarmonyPatch(nameof(DefaultBoundsController.ReadSyncedData))]
        [HarmonyPostfix]
        public static void ReadSyncedData() => SuddenDeathOptionsManager.Instance.ReadSyncedData();

        [HarmonyPatch(nameof(DefaultBoundsController.OnBattleStart))]
        [HarmonyPostfix]
        public static void OnBattleStart() => SuddenDeathOptionsManager.Instance.Reset();

        [HarmonyPatch(nameof(DefaultBoundsController.OnUpdate))]
        [HarmonyPrefix]
        public static bool OnUpdate(DefaultBoundsController __instance) {
            if(SuddenDeathOptionsManager.Instance.ActivateSuddenDeath()) {
                SuddenDeathUtils.ActivateSuddenDeath(__instance, true);
            } else {
                SuddenDeathUtils.ActivateSuddenDeath(__instance, false);
            }
            return false;
        }
    }
}
