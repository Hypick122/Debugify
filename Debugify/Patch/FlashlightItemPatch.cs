using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace Debugify.Patch
{
    [HarmonyPatch(typeof(FlashlightItem))]
    internal class FlashlightItemPatch
    {
        [HarmonyPatch("DiscardItem")]
        [HarmonyPostfix]
        static void DiscardItem(FlashlightItem __instance)
        {
            if (Plugin.Config.FlashlightDiscardFix && __instance.isBeingUsed)
            {
                // bool pocketed = __instance.usingPlayerHelmetLight;
                __instance.isBeingUsed = false;

                __instance.flashlightBulb.enabled = __instance.isBeingUsed;
                __instance.flashlightBulbGlow.enabled = __instance.isBeingUsed;
                if (__instance.playerHeldBy != null)
                {
                    __instance.playerHeldBy.helmetLight.enabled = __instance.isBeingUsed;
                }

                __instance.flashlightAudio.PlayOneShot(__instance.flashlightClips[Random.Range(0, __instance.flashlightClips.Length)]);

                if (Plugin.Config.DEBUGMODE)
                {
                    Plugin.Logger.LogInfo("Flashlight disabled");
                }
            }
        }

        // [HarmonyPatch("EquipItem")]
        // [HarmonyPostfix]
        // static void EquipItem(FlashlightItem __instance) { }

        [HarmonyPatch("SwitchFlashlight")]
        [HarmonyPostfix]
        static void SwitchFlashlight(FlashlightItem __instance, bool on)
        {
            if (Plugin.Config.SwitchFlashlightFix && on)
            {
                for (int slot = 0; slot < __instance.playerHeldBy.ItemSlots.Length; slot++)
                {
                    if (!(__instance.playerHeldBy.ItemSlots[slot] is FlashlightItem otherFlashlight) || otherFlashlight == __instance || !otherFlashlight.isBeingUsed)
                    {
                        continue;
                    }

                    otherFlashlight.isBeingUsed = false;
                    otherFlashlight.PocketItem();

                    if (Plugin.Config.DEBUGMODE)
                    {
                        Plugin.Logger.LogInfo($"The flashlight is disabled in slot {slot} goes out after turning on the flashlight in another slot");
                    }
                }
            }
        }
    }
}