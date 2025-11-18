using UnityEngine;

namespace MoreSuddenDeathOptions.Options.Menus {
    public abstract class SuddenDeathMenu  {
        public SuddenDeathOption SuddenDeathOption { get; private set; }

        public SuddenDeathMenu(SuddenDeathOption suddenDeathOption) {
            SuddenDeathOption = suddenDeathOption;
        }

        public abstract void CreateConfigMenu(GameObject menu);
    }

    public abstract class SuddenDeathMenu<T> : SuddenDeathMenu where T : SuddenDeathOption {
        public T SuddenDeathOptionType { get; private set; }

        public SuddenDeathMenu(T suddenDeathOption) : base(suddenDeathOption) {
            SuddenDeathOptionType = suddenDeathOption;
        }
    }
}
