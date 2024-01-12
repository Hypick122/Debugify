using HarmonyLib;

namespace Debugify.Patch
{
    //[HarmonyPatch(typeof(CentipedeAI))]
    internal static class CentipedeAIPatch
    {
        //[HarmonyPatch("DoAIInterval")]
        public static void DoAIInterval(CentipedeAI __instance)
        {

        }
    }
}
