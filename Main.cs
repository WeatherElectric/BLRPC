using System;
using System.Diagnostics;
using BoneLib;
using System.Reflection;
using BLRPC.Melon;
using MelonLoader;
using BLRPC.Presence.Managers;

namespace BLRPC
{
    public class Main : MelonMod
    {
        internal const string Name = "BLRPC";
        internal const string Description = "Discord Rich Presence for BONELAB";
        internal const string Author = "SoulWithMae";
        internal const string Company = "Weather Electric";
        internal const string Version = "1.5.0";
        internal const string DownloadLink = "https://bonelab.thunderstore.io/package/SoulWithMae/BonelabRichPresence/";

        public static Assembly CurrAsm { get; private set; }
        
        private static bool _hasLoadedLib;
        private static IntPtr _rpcLib;
        
        public static bool IsQuest { get; private set; }

        public static bool DiscordClosed { get; private set; }
        
        public override void OnInitializeMelon()
        {
            ModConsole.Setup(LoggerInstance);
            IsQuest = HelperMethods.IsAndroid();
            if (IsQuest)
            {
                ModConsole.Error("Quest is not supported!");
                return;
            }
            CurrAsm = Assembly.GetExecutingAssembly();
            Preferences.Setup();
            var discord = Process.GetProcessesByName("discord");
            var discordcanary = Process.GetProcessesByName("discordcanary");
            if (discordcanary.Length <= 0 && discord.Length <= 0)
            {
                ModConsole.Error("Neither Discord or Discord Canary are running!");
                DiscordClosed = true;
                return;
            }
            if (discordcanary.Length > 0 && discord.Length > 0)
            {
                ModConsole.Error("You have both Discord and Discord Canary running! Discord may struggle to pick one, and it may not work! Please close one and restart!");
            }
            
            if (!_hasLoadedLib)
            {
                ModConsole.Msg($"Loading Discord SDK from {UserData.DLLPath}", 1);
                _rpcLib = DllTools.LoadLibrary(UserData.DLLPath);
                _hasLoadedLib = true;
            }
            ModConsole.Msg("Initializing RPC", 1);

            var rpcManager = new RpcManager();
            rpcManager.Start();
            
            MelonCoroutines.Start(AvatarManager.Update());
            BoneMenu.Setup();
            Hooking.OnLevelInitialized += OnLevelLoad;
            Hooking.OnLevelUnloaded += OnLevelUnload;
        }

        public override void OnApplicationQuit()
        {
            if (IsQuest || DiscordClosed) return;
            RpcManager.Instance.Dispose();
            if (_hasLoadedLib)
            {
                DllTools.FreeLibrary(_rpcLib);
            }
        }
        
        public override void OnUpdate()
        {
            if (RpcManager.Instance != null)
            {
                if (RpcManager.Instance.RpcStarted)
                {
                    RpcManager.Instance.Update();
                }
            }
        }
        
        private static void OnLevelLoad(LevelInfo levelInfo)
        {
            LevelManager.OnLoad(levelInfo);
        }

        private static void OnLevelUnload()
        {
            LevelManager.LevelLoaded = false;
        }
    }
}