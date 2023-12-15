using System;
using System.IO;
using BLRPC.Melon;
using BLRPC.Presence.Helpers;
using BLRPC.Presence.Patching;
using BLRPC.Presence.Variables;
using BoneLib;

namespace BLRPC.Presence.Managers
{
    public static class LevelManager
    {
        public static bool LevelLoaded;
        
        public static void OnLoad(LevelInfo levelInfo)
        {
            if (Main.IsQuest || Main.DiscordClosed) return;
            LevelLoaded = true;
            ModConsole.Msg($"Level loaded: {levelInfo.title}", 1);
            if (Preferences.ResetKillsOnLevelLoad.Value) NPCDeathCounter.Counter = 0;
            if (Preferences.ResetGunShotsOnLevelLoad.Value) ShotCounter.Counter = 0;
            if (Preferences.ResetDeathsOnLevelLoad.Value) PlayerDeathCounter.Counter = 0;
            SpawnCounter.Counter = 0;
            GlobalVariables.Status = $"In {levelInfo.title}";
            ModConsole.Msg($"Status is {GlobalVariables.Status}", 1);
            GlobalVariables.LargeImageKey = CheckBarcode.CheckMap(levelInfo.barcode);
            ModConsole.Msg($"Large image key is {GlobalVariables.LargeImageKey}", 1);
            GlobalVariables.LargeImageText = levelInfo.title;
            ModConsole.Msg($"Large image text is {GlobalVariables.LargeImageText}", 1);
            switch (Preferences.DetailsMode.Value)
            {
                case DetailsMode.GunShots:
                    GlobalVariables.Details = "Gun Shots Fired: 0";
                    RpcManager.Instance.SetRpc(GlobalVariables.Details, GlobalVariables.Status, GlobalVariables.LargeImageKey, GlobalVariables.LargeImageText, GlobalVariables.SmallImageKey, GlobalVariables.SmallImageText);
                    break;
                case DetailsMode.NPCDeaths:
                    GlobalVariables.Details = "NPC Deaths: 0";
                    RpcManager.Instance.SetRpc(GlobalVariables.Details, GlobalVariables.Status, GlobalVariables.LargeImageKey, GlobalVariables.LargeImageText, GlobalVariables.SmallImageKey, GlobalVariables.SmallImageText);
                    break;
                case DetailsMode.SpawnablesPlaced:
                    GlobalVariables.Details = "Objects Spawned: 0";
                    RpcManager.Instance.SetRpc(GlobalVariables.Details, GlobalVariables.Status, GlobalVariables.LargeImageKey, GlobalVariables.LargeImageText, GlobalVariables.SmallImageKey, GlobalVariables.SmallImageText);
                    break;
                case DetailsMode.SDKMods:
                    GlobalVariables.Details = $"SDK Mods Loaded: {CheckPallets.GetPalletCount()}";
                    RpcManager.Instance.SetRpc(GlobalVariables.Details, GlobalVariables.Status, GlobalVariables.LargeImageKey, GlobalVariables.LargeImageText, GlobalVariables.SmallImageKey, GlobalVariables.SmallImageText);
                    break;
                case DetailsMode.Extraes:
                    GlobalVariables.Details = ExtraesMode.RandomScreamingAboutNonsense();
                    RpcManager.Instance.SetRpc(GlobalVariables.Details, GlobalVariables.Status, GlobalVariables.LargeImageKey, GlobalVariables.LargeImageText, GlobalVariables.SmallImageKey, GlobalVariables.SmallImageText);
                    break;
                case DetailsMode.Entries:
                    GlobalVariables.Details = GetEntry();
                    ModConsole.Msg($"Details are {GlobalVariables.Details}", 1);
                    RpcManager.Instance.SetRpc(GlobalVariables.Details, GlobalVariables.Status, GlobalVariables.LargeImageKey, GlobalVariables.LargeImageText, GlobalVariables.SmallImageKey, GlobalVariables.SmallImageText);
                    break;
                case DetailsMode.PlayerDeaths:
                    GlobalVariables.Details = $"Player Deaths: {PlayerDeathCounter.Counter}";
                    RpcManager.Instance.SetRpc(GlobalVariables.Details, GlobalVariables.Status, GlobalVariables.LargeImageKey, GlobalVariables.LargeImageText, GlobalVariables.SmallImageKey, GlobalVariables.SmallImageText);
                    break;
                default:
                    ModConsole.Error("You don't have a proper mode set!");
                    RpcManager.Instance.SetRpc(null, GlobalVariables.Status, GlobalVariables.LargeImageKey, GlobalVariables.LargeImageText, GlobalVariables.SmallImageKey, GlobalVariables.SmallImageText);
                    break;
            }
        }
        
        private static string GetEntry()
        {
            var rnd = new Random();
            var lines = File.ReadAllLines(UserData.UserEntriesPath);
            var r = rnd.Next(lines.Length);
            return lines[r];
        }
    }
}