using HarmonyLib;
using UnityEngine;

namespace Debugify.Patch
{
    [HarmonyPatch(typeof(FlashlightItem))]
    internal static class FlashlightItemPatch
    {
        [HarmonyPatch("DiscardItem")]
        [HarmonyPostfix]
        static void DiscardItem(FlashlightItem __instance)
        {
            if (Plugin.Config.FlashlightDiscardFix && __instance.isBeingUsed) // PluginConfig.FlashlightDiscardFix.Value
            {
                __instance.isBeingUsed = false;

                __instance.flashlightBulb.enabled = __instance.isBeingUsed;
                __instance.flashlightBulbGlow.enabled = __instance.isBeingUsed;

                __instance.flashlightAudio.PlayOneShot(__instance.flashlightClips[Random.Range(0, __instance.flashlightClips.Length)]);

                if (Plugin.Config.DEBUGMODE)
                {
                    Plugin.Logger.LogInfo("Flashlight disabled");
                }
            }
        }
    }
}