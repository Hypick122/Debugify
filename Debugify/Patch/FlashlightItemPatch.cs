using Debugify;
using Debugify.Core;
using HarmonyLib;

namespace FlashlightFix.Patches
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
                //previousPlayerHeldBy.helmetLight.enabled = false;
                __instance.flashlightBulb.enabled = __instance.isBeingUsed;
                __instance.flashlightBulbGlow.enabled = __instance.isBeingUsed;
            }
        }
    }
}