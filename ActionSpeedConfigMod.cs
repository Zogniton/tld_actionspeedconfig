using MelonLoader;
using UnityEngine;

namespace ActionSpeedConfig {
    internal class ActionSpeedConfigMod : MelonMod {
        public override void OnApplicationStart() {
            ActionSpeedConfigSettings.Instance = new ActionSpeedConfigSettings();
            ActionSpeedConfigSettings.Instance.AddToModSettings("Action Speed Config");
            Debug.Log($"[{InfoAttribute.Name}] version {InfoAttribute.Version} loaded!");
        }
    }
}
