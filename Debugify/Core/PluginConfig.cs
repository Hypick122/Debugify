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
        public bool WalkieTalkieDiscardFix { get; private set; }
        public bool MaskedAnimationFix { get; private set; }
        public bool SlimeBoomboxFix { get; private set; }
        public bool BoomboxPocketFix { get; private set; }

        public PluginConfig(ConfigFile cfg)
        {
            DEBUGMODE = cfg.Bind<bool>(GENERAL, "DEBUG", false, "Enabling this option will allow you to display debugging information in the console.").Value;

            FlashlightDiscardFix = cfg.Bind<bool>(FIXES, "FlashlightDiscardFix", true, "Enabling this option will turn off any flashlights you throw away.").Value;
            WalkieTalkieDiscardFix = cfg.Bind<bool>(FIXES, "WalkieTalkieDiscardFix", false, "Enabling this option will turn off any walkie talkie you throw away.").Value;
            MaskedAnimationFix = cfg.Bind<bool>(FIXES, "MaskedAnimationFix", true, "Fixes a bug where the vomiting animation would not disappear until you died.").Value;

            SlimeBoomboxFix = cfg.Bind<bool>(FIXES, "SlimeBoomboxFix", true, "Fixes a bug where the slime would cause damage while the boombox was playing").Value;
            BoomboxPocketFix = cfg.Bind<bool>(FIXES, "BoomboxPocketFix", true, "Fixes a bug where the boombox would stop playing if switched in the inventory").Value;
        }
    }
}
