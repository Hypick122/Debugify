using HarmonyLib;

namespace Debugify.Patch
{
    [HarmonyPatch(typeof(WalkieTalkie))]
    internal class WalkieTalkiePatch
    {
        [HarmonyPatch("DiscardItem")]
        [HarmonyPostfix]
        static void DiscardItem(WalkieTalkie __instance)
        {
            if (Plugin.Config.WalkieTalkieDiscardFix && __instance.isBeingUsed)
            {
                DisableWalkieTalkie(__instance);

                if (Plugin.Config.DEBUGMODE)
                {
                    Plugin.Logger.LogInfo("Walkie talkie disabled");
                }

            }
        }

        // [HarmonyPatch("EquipItem")]
        // [HarmonyPostfix]
        // static void EquipItem(WalkieTalkie __instance) { }

        [HarmonyPatch("SwitchWalkieTalkieOn")]
        [HarmonyPostfix]
        static void SwitchWalkieTalkieOn(WalkieTalkie __instance, bool on)
        {
            if (Plugin.Config.SwitchWalkieTalkieFix && on)
            {
                for (int slot = 0; slot < __instance.playerHeldBy.ItemSlots.Length; slot++)
                {
                    if (!(__instance.playerHeldBy.ItemSlots[slot] is WalkieTalkie otherWalkieTalkie) || otherWalkieTalkie != __instance || otherWalkieTalkie.isBeingUsed)
                    {
                        continue;
                    }

                    DisableWalkieTalkie(otherWalkieTalkie);

                    if (Plugin.Config.DEBUGMODE)
                    {
                        Plugin.Logger.LogInfo($"The walkie talkie is disabled in slot {slot} goes out after turning on the walkie talkie in another slot");
                    }
                }
            }
        }

        private static void DisableWalkieTalkie(WalkieTalkie __instance)
        {
            __instance.isBeingUsed = false;

            __instance.mainObjectRenderer.sharedMaterial = __instance.offMaterial;
            __instance.walkieTalkieLight.enabled = __instance.isBeingUsed;

            __instance.EnableWalkieTalkieListening(enable: false);

            __instance.thisAudio.PlayOneShot(__instance.switchWalkieTalkiePowerOff);
        }
    }
}