using HarmonyLib;
using MoreSuddenDeathOptions.Utils;
using System;
using System.Collections.Generic;
using TMPro;
using UnboundLib;
using UnboundLib.Utils.UI;
using UnityEngine;
using UnityEngine.UI;

namespace MoreSuddenDeathOptions.Options.Menus {
    public class SuddenDeathMenuManager : MonoBehaviour {
        private readonly Dictionary<Type, Type> menuTypes = new Dictionary<Type, Type>();
        private readonly List<SuddenDeathMenu> suddenDeathMenus = new List<SuddenDeathMenu>();

        public static SuddenDeathMenuManager Instance { get; private set; }

        public void RegisterMenu<O, M>()
            where O : SuddenDeathOption
            where M : SuddenDeathMenu {
            menuTypes[typeof(O)] = typeof(M);
        }


        internal void CreateAllMenus(GameObject parent) {
            InitializeMenus();

            MenuHandler.CreateText($"<b>{MoreSuddenDeathOptions.ModName}</b>", parent, out TextMeshProUGUI _, 70);
            MenuHandler.CreateText(" ", parent, out TextMeshProUGUI _, 50);

            foreach(var menu in suddenDeathMenus) {
                var controllerMenu = MenuHandler.CreateMenu(menu.SuddenDeathOption.Name, () => { }, parent, 40, parentForMenu: parent.transform.parent.gameObject);

                MenuHandler.CreateText($"<b>{menu.SuddenDeathOption.Name} Options</b>", controllerMenu, out TextMeshProUGUI _, 70);
                menu.CreateConfigMenu(controllerMenu);
            }

            MapEmbiggener.MapEmbiggener instance = (MapEmbiggener.MapEmbiggener)AccessTools.Field(typeof(MapEmbiggener.MapEmbiggener), "instance").GetValue(null);
            ((Toggle)instance.GetFieldValue("suddenDeathModeToggle")).gameObject.SetActive(false);
            ((Toggle)instance.GetFieldValue("chaosModeToggle")).gameObject.SetActive(false);
            ((Toggle)instance.GetFieldValue("chaosModeClassicToggle")).gameObject.SetActive(false);

            MenuUtils.CreateMenu("Sudden Death Options", ((Toggle)instance.GetFieldValue("chaosModeClassicToggle")).transform.parent.gameObject, 30, parentForMenu: parent);
        }

        internal void InitializeMenus() {
            foreach(var kvp in menuTypes) {
                Type optionType = kvp.Key;
                Type menuType = kvp.Value;

                SuddenDeathOption option = SuddenDeathOptionsManager.Instance.GetOptionByType(optionType);
                SuddenDeathMenu menuInstance = (SuddenDeathMenu)Activator.CreateInstance(menuType, option);

                suddenDeathMenus.Add(menuInstance);
            }
        }


        private void Awake() {
            if(Instance != null) {
                Destroy(this);
                return;
            }

            Instance = this;
        }
    }
}
