using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Debugify.Patch
{
    internal static class BoomboxItemPatch
    {
        [HarmonyPatch(typeof(BoomboxItem), "PocketItem")]
        [HarmonyPrefix]
        static bool PocketItem(BoomboxItem __instance)
        {
            if (Plugin.BoomboxPocketFix.Value)
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
