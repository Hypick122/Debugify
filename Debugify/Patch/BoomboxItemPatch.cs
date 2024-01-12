using HarmonyLib;

namespace Debugify.Patch
{
    [HarmonyPatch(typeof(BoomboxItem))]
    internal static class BoomboxItemPatch
    {
        [HarmonyPatch("PocketItem")]
        [HarmonyPrefix]
        static bool PocketItem(BoomboxItem __instance)
        {
            if (Plugin.Config.BoomboxPocketFix)
            {
                GrabbableObject component = __instance.GetComponent<GrabbableObject>();
                if (component != null)
                {
                    component.EnableItemMeshes(enable: false);
                }
            }
            return false;
        }
    }
}
