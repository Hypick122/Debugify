using HarmonyLib;

namespace Debugify.Patch
{
    [HarmonyPatch(typeof(WalkieTalkie))]
    internal static class WalkieTalkiePatch
    {
        [HarmonyPatch("DiscardItem")]
        [HarmonyPostfix]
        static void DiscardItem(WalkieTalkie __instance)
        {
            if (Plugin.Config.WalkieTalkieDiscardFix && __instance.isBeingUsed) // PluginConfig.FlashlightDiscardFix.Value
            {
                __instance.isBeingUsed = false;

                __instance.mainObjectRenderer.sharedMaterial = __instance.offMaterial;
                __instance.walkieTalkieLight.enabled = __instance.isBeingUsed;

                __instance.thisAudio.PlayOneShot(__instance.switchWalkieTalkiePowerOff);

                if (Plugin.Config.DEBUGMODE)
                {
                    Plugin.Logger.LogInfo("Walkie talkie disabled");
                }
            }
        }
    }
}