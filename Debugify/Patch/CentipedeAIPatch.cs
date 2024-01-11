using HarmonyLib;

namespace Debugify.Patch
{
    internal static class CentipedeAIPatch
    {
        //[HarmonyPatch(typeof(CentipedeAI), nameof(DoAIInterval))]
        public static void DoAIInterval(CentipedeAI __instance)
        {

        }
    }
}
