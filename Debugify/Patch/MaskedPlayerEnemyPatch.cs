using HarmonyLib;

namespace Debugify.Patch
{
    [HarmonyPatch(typeof(MaskedPlayerEnemy))]
    internal static class MaskedPlayerEnemyPatch
    {
        [HarmonyPatch("CancelSpecialAnimationWithPlayer")]
        [HarmonyPrefix]
        static void CancelSpecialAnimationWithPlayer(MaskedPlayerEnemy __instance)
        {
            __instance.FinishKillAnimation();
            if (Plugin.Config.MaskedAnimationFix && __instance.inSpecialAnimationWithPlayer == GameNetworkManager.Instance.localPlayerController)
            {
                HUDManager.Instance.HUDAnimator.SetBool("biohazardDamage", value: false);
                HUDManager.Instance.HideHUD(hide: true);
                HUDManager.Instance.HideHUD(hide: false);

                if (Plugin.Config.DEBUGMODE)
                {
                    Plugin.Logger.LogInfo("biohazardDamage animation disabled");
                }
            }
        }
    }
}
