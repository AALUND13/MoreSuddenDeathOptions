using HarmonyLib;
using TMPro;
using UnboundLib.Utils.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MoreSuddenDeathOptions.Utils {
    internal static class MenuUtils {
        public static void CreateMenu(string name, GameObject parentForButton, int size = 50, GameObject parentForMenu = null) {
            MenuHandler.CreateButton(name, parentForButton, () => {
                parentForMenu.GetComponent<ListMenuPage>().Open();
                parentForButton.GetComponentInParent<GoBack>().goBackEvent.Invoke();
            }, size);
        }
    }
}
