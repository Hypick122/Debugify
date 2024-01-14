using GameNetcodeStuff;
using HarmonyLib;

namespace Debugify.Patch
{
    // [HarmonyPatch(typeof(PlayerControllerBPatch))]
    internal class PlayerControllerBPatch
    {
    //     [HarmonyPatch("SwitchToItemSlot")]
    //     [HarmonyPostfix]
        static void SwitchToItemSlot(PlayerControllerB __instance) { }
    }
}
