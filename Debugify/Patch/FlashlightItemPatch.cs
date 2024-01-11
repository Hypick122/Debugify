using Debugify;
using HarmonyLib;
using UnityEngine;

namespace FlashlightFix.Patches
{
    internal static class FlashlightItemPatch
    {

        [HarmonyPatch(typeof(FlashlightItem), nameof(DiscardItem))]
        [HarmonyPostfix]
        static void DiscardItem(FlashlightItem __instance)
        {
            if (Plugin.FlashlightDiscardFix.Value && __instance.isBeingUsed) // PluginConfig.FlashlightDiscardFix.Value
            {
                __instance.isBeingUsed = false;

                __instance.flashlightBulb.enabled = __instance.isBeingUsed;
                __instance.flashlightBulbGlow.enabled = __instance.isBeingUsed;

                __instance.flashlightAudio.PlayOneShot(__instance.flashlightClips[Random.Range(0, __instance.flashlightClips.Length)]);
            }
        }
    }
}