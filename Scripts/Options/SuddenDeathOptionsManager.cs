using BepInEx.Configuration;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnboundLib;
using UnityEngine;

namespace MoreSuddenDeathOptions.Options {
    public class SuddenDeathOptionsManager : MonoBehaviour {
        private readonly Dictionary<Type, SuddenDeathOption> options = new Dictionary<Type, SuddenDeathOption>();
        private readonly Dictionary<string, SuddenDeathOption> optionKeyMaps = new Dictionary<string, SuddenDeathOption>();

        public IEnumerable<SuddenDeathOption> Options => options.Values;
        public static SuddenDeathOptionsManager Instance { get; private set; }


        public bool ActivateSuddenDeath() {
            return options.Values.Any(o => o.ActivateSuddenDeath());
        }

        public void RegisterOption<T>() where T : SuddenDeathOption, new() {
            Type t = typeof(T);

            if(options.ContainsKey(t))
                throw new Exception($"SuddenDeathOption '{t.Name}' is already registered.");

            T option = new T();
            options.Add(t, option);
            optionKeyMaps.Add(option.Name, option);
        }

        public T GetOptionByType<T>() where T : SuddenDeathOption {
            if(options.ContainsKey(typeof(T))) return (T)options[typeof(T)];
            return null;
        }

        public SuddenDeathOption GetOptionByType(Type type) {
            if(options.ContainsKey(type)) return options[type];
            return null;
        }


        internal void SetDataToSync() {
            foreach(var controller in options.Values) {
                controller.SetDataToSync();
            }
        }

        internal void ReadSyncedData() {
            foreach(var controller in options.Values) {
                controller.ReadSyncedData();
            }
        }

        internal void Reset() {
            foreach(var controller in options.Values) {
                controller.OnReset();
            }
        }


        private void Awake() {
            if(Instance != null) {
                Destroy(this);
                return;
            }

            Instance = this;
        }

        private void Start() {
            AccessTools.PropertySetter(typeof(MapEmbiggener.MapEmbiggener), "suddenDeathMode").Invoke(null, new object[] { false });
            AccessTools.PropertySetter(typeof(MapEmbiggener.MapEmbiggener), "chaosMode").Invoke(null, new object[] { false });
            AccessTools.PropertySetter(typeof(MapEmbiggener.MapEmbiggener), "chaosModeClassic").Invoke(null, new object[] { false });
        }
    }
}
