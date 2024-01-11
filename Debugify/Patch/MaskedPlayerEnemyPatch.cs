using HarmonyLib;

namespace Debugify.Patch
{
    internal static class MaskedPlayerEnemyPatch
    {
        [HarmonyPatch(typeof(MaskedPlayerEnemy), "CancelSpecialAnimationWithPlayer")]
        [HarmonyPrefix]
        static void CancelSpecialAnimationWithPlayer(MaskedPlayerEnemy __instance)
        {
            __instance.FinishKillAnimation();
            if (Plugin.MaskedAnimationFix.Value && __instance.inSpecialAnimationWithPlayer == GameNetworkManager.Instance.localPlayerController)
            {
                HUDManager.Instance.HUDAnimator.SetBool("biohazardDamage", value: false);
                HUDManager.Instance.HideHUD(hide: true);
                HUDManager.Instance.HideHUD(hide: false);

                if (Plugin.DEBUGMODE.Value)
                {
                    Plugin.Logger.LogInfo("biohazardDamage animation disabled");
                }
            }
        }
    }
}
