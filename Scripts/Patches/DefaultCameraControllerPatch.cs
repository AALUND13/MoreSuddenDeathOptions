using MoreSuddenDeathOptions.Options;
using MoreSuddenDeathOptions.Utils;
using HarmonyLib;
using MapEmbiggener.Controllers.Default;

namespace MoreSuddenDeathOptions.Patches {
    [HarmonyPatch(typeof(DefaultCameraController), nameof(DefaultCameraController.OnUpdate))]
    internal class DefaultCameraControllerPatch {
        public static bool Prefix(DefaultCameraController __instance) {
            if(SuddenDeathOptionsManager.Instance.ActivateSuddenDeath()) {
                SuddenDeathUtils.ActivateSuddenDeathCamera(__instance, true);
            } else {
                SuddenDeathUtils.ActivateSuddenDeathCamera(__instance, false);
            }
            return false;
        }
    }
}
