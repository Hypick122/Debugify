using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using Debugify.Core;
using Debugify.Patch;
using HarmonyLib;

namespace Debugify
{
    [BepInPlugin(Metadata.PLUGIN_GUID, Metadata.PLUGIN_NAME, Metadata.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony(Metadata.PLUGIN_GUID);

        internal static Plugin Instance { get; private set; }

        internal static new ManualLogSource Logger { get; private set; }
        //public static new PluginConfig Config { get; private set; }

        private static string GENERAL = "General";
        public static ConfigEntry<bool> DEBUGMODE;

        private static string FIXES = "Fixes";
        public static ConfigEntry<bool> FlashlightDiscardFix;
        public static ConfigEntry<bool> WalkieTalkieDiscardFix;
        public static ConfigEntry<bool> MaskedAnimationFix;
        public static ConfigEntry<bool> SlimeBoomboxFix;
        public static ConfigEntry<bool> BoomboxPocketFix;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            Logger = base.Logger;
            //Config = new(base.Config);
            PluginConfig();

            harmony.PatchAll(typeof(Plugin));
            harmony.PatchAll(typeof(FlashlightItemPatch));
            harmony.PatchAll(typeof(WalkieTalkiePatch));
            harmony.PatchAll(typeof(MaskedPlayerEnemyPatch));
            harmony.PatchAll(typeof(BlobAIPatch));
            harmony.PatchAll(typeof(BoomboxItemPatch));

            Logger.LogInfo($"Plugin {Metadata.PLUGIN_GUID} is loaded!");
        }

        public void PluginConfig()
        {
            DEBUGMODE = Instance.Config.Bind(GENERAL, "DEBUG", true, "Enabling this option will allow you to display debugging information in the console.");

            FlashlightDiscardFix = Instance.Config.Bind(FIXES, "FlashlightDiscardFix", true, "Enabling this option will turn off any flashlights you throw away.");
            WalkieTalkieDiscardFix = Instance.Config.Bind(FIXES, "WalkieTalkieDiscardFix", false, "Enabling this option will turn off any walkie talkie you throw away.");
            MaskedAnimationFix = Instance.Config.Bind(FIXES, "MaskedAnimationFix", true, "Fixes a bug where the vomiting animation would not disappear until you died.");

            SlimeBoomboxFix = Instance.Config.Bind(FIXES, "SlimeBoomboxFix", true, "Fixes a bug where the slime would cause damage while the boombox was playing");
            BoomboxPocketFix = Instance.Config.Bind(FIXES, "BoomboxPocketFix", true, "Fixes a bug where the boombox would stop playing if switched in the inventory");
        }
    }
}
