using HarmonyLib;

namespace Debugify.Patch
{
    internal static class WalkieTalkiePatch
    {
        [HarmonyPatch(typeof(WalkieTalkie), "DiscardItem")]
        [HarmonyPostfix]
        static void DiscardItem(WalkieTalkie __instance)
        {
            if (Plugin.WalkieTalkieDiscardFix.Value && __instance.isBeingUsed) // PluginConfig.FlashlightDiscardFix.Value
            {
                __instance.isBeingUsed = false;

                __instance.mainObjectRenderer.sharedMaterial = __instance.offMaterial;
                __instance.walkieTalkieLight.enabled = __instance.isBeingUsed;

                __instance.thisAudio.PlayOneShot(__instance.switchWalkieTalkiePowerOff);

                if (Plugin.DEBUGMODE.Value)
                {
                    Plugin.Logger.LogInfo("Walkie talkie disabled");
                }
            }
        }
    }
}