using BepInEx;
using BepInEx.Logging;
using COTL_API.Localization;
using HarmonyLib;
using System.Collections.Generic;
using System.IO;

namespace LambRenamed
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [BepInDependency("io.github.xhayper.COTL_API")]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "clueless.cotl.LambRenamed";
        public const string PluginName = "LambRenamed";
        public const string PluginVer = "1.0.0";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;

        private void Awake()
        {
            Logger.LogInfo($"Loaded {PluginName}!");
            Plugin.Log = base.Logger;

            PluginPath = Path.GetDirectoryName(Info.Location);
            
            string localizationPath = Path.Combine(Plugin.PluginPath, "Assets", "Lambert.language");
            
            Localization.LoadLocalization("Lamb Renamed", localizationPath);
        }

        private void OnEnable()
        {
            Harmony.PatchAll();
            Logger.LogInfo($"Loaded {PluginName}!");
        }

        private void OnDisable()
        {
            Harmony.UnpatchSelf();
            Logger.LogInfo($"Unloaded {PluginName}!");
        }
    }
}