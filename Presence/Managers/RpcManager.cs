using System;
using BLRPC.Melon;
using Discord;

namespace BLRPC.Presence.Managers
{
    internal class RpcManager
    {
        public static RpcManager Instance { get; private set; }
        
        public bool RpcStarted { get; private set; }
        private Discord.Discord Discord;
        private ActivityManager ActivityManager;
        private readonly long StartTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        
        public void Start()
        {
            Instance = this;
            ModConsole.Msg("Initializing RPC", 1);
            Discord = new global::Discord.Discord(Preferences.DiscordAppId.Value, (ulong)CreateFlags.Default);
            ModConsole.Msg($"Discord is {Discord}", 1);
            ModConsole.Msg($"Application ID is {Preferences.DiscordAppId.Value}", 1);
            ActivityManager = Discord.GetActivityManager();
            ModConsole.Msg($"Activity manager is {ActivityManager}", 1);
            SetRpc(null, "Loading Game", "bonelab", "BONELAB", null, null);
        }

        internal void Update()
        {
            Discord.RunCallbacks();
        }

        public void Dispose()
        {
            Discord.Dispose();
        }
        
        public void SetRpc(string details, string state, string largeImageKey, string largeImageText, string smallImageKey, string smallImageText)
        {
            ModConsole.Msg($"Setting activity with details {details}, state {state}, large image key {largeImageKey}, and large image text {largeImageText}", 1);
            var activity = new Activity
            {
                State = state,
                Details = details,
                Timestamps =
                {
                    Start = StartTime
                },
                Assets =
                {
                    LargeImage = largeImageKey,
                    LargeText = largeImageText,
                    SmallImage = smallImageKey,
                    SmallText = smallImageText
                },
                Instance = false
            };
            ActivityManager.UpdateActivity(activity, (result) =>
            {
                if (result == global::Discord.Result.Ok)
                {
                    ModConsole.Msg("Successfully set activity!", 1);
                }
                else
                {
                    ModConsole.Error("Failed to set activity!");
                }
            });
        }
    }
}