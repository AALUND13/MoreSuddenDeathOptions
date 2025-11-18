using MoreSuddenDeathOptions.Options.BuiltIn;
using TMPro;
using UnboundLib.Utils.UI;
using UnityEngine;

namespace MoreSuddenDeathOptions.Options.Menus.BuiltIn {
    public class TriggerSuddeenDeathTimerMenu : SuddenDeathMenu<TriggerSuddeenDeathTimer> {
        public TriggerSuddeenDeathTimerMenu(TriggerSuddeenDeathTimer suddenDeathOption) : base(suddenDeathOption) { }

        public override void CreateConfigMenu(GameObject menu) {
            // Enable Option
            MenuHandler.CreateToggle(SuddenDeathOptionType.EnableConfig.Value, "Enable Sudden Death Option", menu, value => {
                SuddenDeathOptionType.Enable = value;
                SuddenDeathOptionType.EnableConfig.Value = value;
            });
            MenuHandler.CreateText(" ", menu, out TextMeshProUGUI _, 30);

            // Settings Options
            MenuHandler.CreateSlider("Trigger When <b>N</b> Amount of Time Pass", menu, 30, 0, 120, SuddenDeathOptionType.TriggerWhenNTimePassConfig.Value, value => {
                SuddenDeathOptionType.TriggerWhenNTimePassConfig.Value = value;
                SuddenDeathOptionType.TriggerWhenNTimePass = value;
            }, out var _, true);
        }
    }
}
