using BepInEx.Configuration;

namespace Debugify.Core
{
    public class PluginConfig
    {
        private static string GENERAL = "GENERAL";
        private static string FIXES = "FIXES";

        // GENERAL
        public bool DEBUGMODE { get; private set; }

        // FIXES
        public bool FlashlightDiscardFix { get; private set; }
        public bool SwitchFlashlightFix { get; private set; }
        public bool WalkieTalkieDiscardFix { get; private set; }
        public bool SwitchWalkieTalkieFix { get; private set; }
        public bool MaskedAnimationFix { get; private set; }
        public bool SlimeBoomboxFix { get; private set; }
        public bool BoomboxPocketFix { get; private set; }

        public PluginConfig(ConfigFile cfg)
        {
            DEBUGMODE = cfg.Bind<bool>(GENERAL, "DEBUG", true, "Enabling this option will allow you to display debugging information in the console.").Value; // false

            FlashlightDiscardFix = cfg.Bind<bool>(FIXES, "FlashlightDiscardFix", true, "Enabling this option will turn off any flashlights you throw away.").Value;
            SwitchFlashlightFix = cfg.Bind<bool>(FIXES, "SwitchFlashlightFix", true, "When you turn on a flashlight, it turns off all other flashlights in your inventory.").Value;

            WalkieTalkieDiscardFix = cfg.Bind<bool>(FIXES, "WalkieTalkieDiscardFix", false, "Enabling this option will turn off any walkie talkie you throw away.").Value;
            SwitchWalkieTalkieFix = cfg.Bind<bool>(FIXES, "SwitchWalkieTalkieFix", true, "When you turn on a walkie talkie, it turns off all other walkie talkie in your inventory.").Value;

            MaskedAnimationFix = cfg.Bind<bool>(FIXES, "MaskedAnimationFix", true, "Fixes a bug where the vomiting animation would not disappear until you died.").Value;
            SlimeBoomboxFix = cfg.Bind<bool>(FIXES, "SlimeBoomboxFix", true, "Fixes a bug where the slime would cause damage while the boombox was playing").Value;
            BoomboxPocketFix = cfg.Bind<bool>(FIXES, "BoomboxPocketFix", true, "Fixes a bug where the boombox would stop playing if switched in the inventory").Value;
            // Future
            //FireExitFix = cfg.Bind<bool>(FIXES, "FireExixFix", true, "").Value;
            // ItemsFallFix = cfg.Bind<bool>(FIXES, "ItemsFallFix", true, "").Value;
            //PlayerDeadTeleportFix = cfg.Bind<bool>(FIXES, "PlayerDeadTeleportFix", true, "").Value;

            // CentipedeLagFix = cfg.Bind<bool>(FIXES, "CentipedeLagFix", true, "").Value;
            // PathfindingLagFix = cfg.Bind<bool>(FIXES, "PathfindingLagFix", true, "").Value;

            //BoomboxSyncFix = cfg.Bind<bool>(FIXES, "BoomboxSyncFix", true, "").Value;
            //DoorFix = cfg.Bind<bool>(FIXES, "DoorFix", true, "").Value;
            //DissonanceLagFix = cfg.Bind<bool>(FIXES, "DissonanceLagFix", true, "").Value;
            //ScanFix = cfg.Bind<bool>(FIXES, "ScanFix", true, "").Value;
        }
    }
}
