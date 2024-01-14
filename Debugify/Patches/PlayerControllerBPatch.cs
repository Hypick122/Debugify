using GameNetcodeStuff;
using HarmonyLib;

namespace Debugify.Patch
{
    // [HarmonyPatch(typeof(PlayerControllerBPatch))]
    internal class PlayerControllerBPatch
    {
        [HarmonyPatch("SwitchToItemSlot")]
        [HarmonyPostfix]
        static void SwitchToItemSlot(PlayerControllerB __instance) { }

        [HarmonyPatch("ScrollMouse_performed")]
        [HarmonyPostfix]
        static int ScrollMouse_performed(bool forward)
        {

        }
    }
}
