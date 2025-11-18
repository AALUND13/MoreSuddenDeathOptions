using MoreSuddenDeathOptions.Options.BuiltIn;
using TMPro;
using UnboundLib.Utils.UI;
using UnityEngine;

namespace MoreSuddenDeathOptions.Options.Menus.BuiltIn {
    public class TriggerSuddeenDeathPlayersMenu : SuddenDeathMenu<TriggerSuddeenDeathPlayers> {
        public TriggerSuddeenDeathPlayersMenu(TriggerSuddeenDeathPlayers suddenDeathOption) : base(suddenDeathOption) { }

        public override void CreateConfigMenu(GameObject menu) {
            // Enable Option
            MenuHandler.CreateToggle(SuddenDeathOptionType.EnableConfig.Value, "Enable Sudden Death Option", menu, value => {
                SuddenDeathOptionType.Enable = value;
                SuddenDeathOptionType.EnableConfig.Value = value;
            });
            MenuHandler.CreateText(" ", menu, out TextMeshProUGUI _, 30);

            // Settings Options
            MenuHandler.CreateSlider("Enable When Above <b>N</b> Amount of Players", menu, 30, 0, 5, SuddenDeathOptionType.EnableWhenAboveNPlayersConfig.Value, value => {
                SuddenDeathOptionType.EnableWhenAboveNPlayersConfig.Value = (int)value;
                SuddenDeathOptionType.EnableWhenAboveNPlayers = (int)value;
            }, out var _, true);
            MenuHandler.CreateSlider("Trigger When Below or Equal <b>N</b> Amount of Players", menu, 30, 0, 5, SuddenDeathOptionType.TriggerWhenBelowOrEqualNPlayersConfig.Value, value => {
                SuddenDeathOptionType.TriggerWhenBelowOrEqualNPlayersConfig.Value = (int)value;
                SuddenDeathOptionType.TriggerWhenBelowOrEqualNPlayers = (int)value;
            }, out var _, true);
        }
    }
}
