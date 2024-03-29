﻿using HarmonyLib;

namespace Debugify.Patch
{
    [HarmonyPatch(typeof(BlobAI))]
    internal class BlobAIPatch
    {
        [HarmonyPatch("OnCollideWithPlayer")]
        [HarmonyPrefix]
        static bool OnCollideWithPlayer(BlobAI __instance)
        {
            if (Plugin.Config.SlimeBoomboxFix)
            {
                float tamedTimer = Traverse.Create(__instance).Field("tamedTimer").GetValue<float>();
                float angeredTimer = Traverse.Create(__instance).Field("angeredTimer").GetValue<float>();

                return !(tamedTimer > 0f && angeredTimer <= 0f);
            }
            return true;
        }
    }
}