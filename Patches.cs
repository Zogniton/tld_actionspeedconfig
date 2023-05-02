using Harmony;
using UnityEngine;

namespace ActionSpeedConfig {

    // Search containers
    [HarmonyPatch(typeof(Container), "BeginContainerInteraction")]
    internal static class ActionSearchContainer {
        static void Prefix(ref float searchTimeSeconds) {
            searchTimeSeconds = ActionSpeedConfigSettings.Instance.containerSearchTime;
        }
    }

    // Harvest carcas
    [HarmonyPatch(typeof(Panel_BodyHarvest), "StartHarvest")]
    internal static class ActionHarvestBody {
        static void Prefix(ref Panel_BodyHarvest __instance) {
            Debug.Log($"StartHarvest seconds: {__instance.m_HarvestTimeSeconds}");
            __instance.m_HarvestTimeSeconds = ActionSpeedConfigSettings.Instance.carcasHarvestTime;
            Debug.Log($"StartHarvest seconds: {__instance.m_HarvestTimeSeconds}");
            Debug.Log($"StartHarvest ProgressBarTimeSeconds: {__instance.m_ProgressBarTimeSeconds}");
        }
    }

    // Quarter carcas
    [HarmonyPatch(typeof(Panel_BodyHarvest), "StartQuarter")]
    internal static class ActionHarvestQuarter {
        static void Prefix(ref Panel_BodyHarvest __instance) {
            __instance.m_HarvestTimeSeconds = ActionSpeedConfigSettings.Instance.carcasHarvestTime;
        }
    }

    // Drinking
    [HarmonyPatch(typeof(PlayerManager), "DrinkFromWaterSupply")]
    public class ActionDrinking {
        public static void Prefix(ref WaterSupply ws) {
            ws.m_TimeToDrinkSeconds = ActionSpeedConfigSettings.Instance.eatTime;
        }

    }

    // Eating
    [HarmonyPatch(typeof(PlayerManager), "UseFoodInventoryItem")]
    public class ActionEating {
        public static void Prefix(ref GearItem gi) {
            gi.m_FoodItem.m_TimeToEatSeconds = ActionSpeedConfigSettings.Instance.eatTime;
        }

    }

    // Harvesting plants, etc
    [HarmonyPatch(typeof(Harvestable), "DoHarvest")]
    public class ActionHarvestingPlant {
        public static void Prefix(Harvestable __instance) {
            __instance.m_SecondsToHarvest = ActionSpeedConfigSettings.Instance.plantHarvestTime;
        }

    }

    // Generic Actions
    [HarmonyPatch(typeof(Panel_GenericProgressBar), "Launch")]
    public class ActionGeneric {
        public static void Prefix(string name, ref float seconds) {
            Debug.Log($"Action name: {name} seconds: {seconds}");
            if (name == Localization.Get("GAMEPLAY_FishingProgress") || 
                name == Localization.Get("GAMEPLAY_BreakIceProgress")) {
                seconds = ActionSpeedConfigSettings.Instance.fishingTime;
            }
        }
    }
}



