using HarmonyLib;
using UnityEngine;

namespace Debugify.Patch
{
    internal static class FlashlightItemPatch
    {

        [HarmonyPatch(typeof(FlashlightItem), "DiscardItem")]
        [HarmonyPostfix]
        static void DiscardItem(FlashlightItem __instance)
        {
            if (Plugin.FlashlightDiscardFix.Value && __instance.isBeingUsed) // PluginConfig.FlashlightDiscardFix.Value
            {
                __instance.isBeingUsed = false;

                __instance.flashlightBulb.enabled = __instance.isBeingUsed;
                __instance.flashlightBulbGlow.enabled = __instance.isBeingUsed;

                __instance.flashlightAudio.PlayOneShot(__instance.flashlightClips[Random.Range(0, __instance.flashlightClips.Length)]);

                if (Plugin.DEBUGMODE.Value)
                {
                    Plugin.Logger.LogInfo("Flashlight disabled");
                }
            }
        }
    }
}