using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using Debugify.Core;
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

            Logger.LogInfo($"Plugin {Metadata.PLUGIN_GUID} is loaded!");
        }

        public void PluginConfig()
        {
            FlashlightDiscardFix = Instance.Config.Bind(GENERAL, "FlashlightDiscardFix", true, "Enabling this option will turn off any flashlights you throw away.");
        }
    }
}
