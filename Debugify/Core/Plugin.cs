using BepInEx;
using BepInEx.Logging;
using Debugify.Core;
using HarmonyLib;

namespace Debugify
{
    [BepInPlugin(Metadata.PLUGIN_GUID, Metadata.PLUGIN_NAME, Metadata.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static Plugin Instance { get; private set; }

        private readonly Harmony harmony = new Harmony(Metadata.PLUGIN_GUID);

        public static new PluginConfig Config { get; internal set; }

        internal static new ManualLogSource Logger { get; private set; }

        private void Awake()
        {
            if (Instance == null) Instance = this;

            Logger = base.Logger;
            Config = new(base.Config);

            harmony.PatchAll();

            Logger.LogInfo($"Plugin {Metadata.PLUGIN_GUID} is loaded!");
        }
    }
}