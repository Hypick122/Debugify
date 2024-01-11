using HarmonyLib;

namespace Debugify.Patch
{
    internal static class WalkieTalkiePatch
    {
        [HarmonyPatch(typeof(WalkieTalkie), nameof(DiscardItem))]
        [HarmonyPostfix]
        static void DiscardItem(WalkieTalkie __instance)
        {
            if (Plugin.WalkieTalkieDiscardFix.Value && __instance.isBeingUsed) // PluginConfig.FlashlightDiscardFix.Value
            {
                __instance.isBeingUsed = false;

                __instance.mainObjectRenderer.sharedMaterial = __instance.offMaterial;
                __instance.walkieTalkieLight.enabled = __instance.isBeingUsed;

                __instance.thisAudio.PlayOneShot(__instance.switchWalkieTalkiePowerOff);
            }
        }
    }
}