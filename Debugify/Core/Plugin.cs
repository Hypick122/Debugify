using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using Debugify.Core;
using Debugify.Patch;
using FlashlightFix.Patches;
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
        public static ConfigEntry<bool> FlashlightDiscardFix;
        public static ConfigEntry<bool> WalkieTalkieDiscardFix;
        public static ConfigEntry<bool> MaskedAnimationFix;

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

            Logger.LogInfo($"Plugin {Metadata.PLUGIN_GUID} is loaded!");
        }

        public void PluginConfig()
        {
            FlashlightDiscardFix = Instance.Config.Bind(GENERAL, "FlashlightDiscardFix", true, "Enabling this option will turn off any flashlights you throw away.");
            WalkieTalkieDiscardFix = Instance.Config.Bind(GENERAL, "WalkieTalkieDiscardFix", false, "Enabling this option will turn off any walkie talkie you throw away.");
            MaskedAnimationFix = Instance.Config.Bind(GENERAL, "MaskedAnimationFix", true, "Fixes a bug where the vomiting animation would not disappear until you died.");
        }
    }
}
