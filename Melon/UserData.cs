using System.IO;
using BoneLib;
using MelonLoader;

namespace BLRPC.Melon
{
    internal static class UserData
    {
        public static readonly string UserDataDirectory = Path.Combine(MelonUtils.UserDataDirectory, "Weather Electric/BLRPC");
        public static readonly string LegacyDirectory = Path.Combine(MelonUtils.UserDataDirectory, "BLRPC");
        public static readonly string DLLPath = Path.Combine(UserDataDirectory, "discord_game_sdk.dll");
        public static readonly string UserEntriesPath = Path.Combine(UserDataDirectory, "UserEntries.txt");

        public static void Setup()
        {
            if (!Directory.Exists(UserDataDirectory))
            {
                ModConsole.Msg($"User data directory not found, creating at {UserDataDirectory}", 1);
                Directory.CreateDirectory(UserDataDirectory);
            }
            if (!File.Exists(DLLPath))
            {
                ModConsole.Msg($"Discord SDK not unpacked, checking legacy path", 1);
                if (Directory.Exists(LegacyDirectory) && File.Exists(Path.Combine(LegacyDirectory, "discord_game_sdk.dll")))
                {
                    File.Move(Path.Combine(LegacyDirectory, "discord_game_sdk.dll"), DLLPath);
                }
                else
                {
                    ModConsole.Msg($"Legacy path not found, creating at {DLLPath}", 1);
                    File.WriteAllBytes(DLLPath, HelperMethods.GetResourceBytes(Main.CurrAsm, "discord_game_sdk.dll"));
                }
            }
            if (!File.Exists(UserEntriesPath))
            {
                ModConsole.Msg($"User entries file not unpacked, checking legacy path", 1);
                if (Directory.Exists(LegacyDirectory) && File.Exists(Path.Combine(LegacyDirectory, "UserEntries.txt")))
                {
                    var entries = Path.Combine(LegacyDirectory, "UserEntries.txt");
                    File.Move(entries, UserEntriesPath);
                }
                else
                {
                    ModConsole.Msg($"Legacy path not found, creating at {UserEntriesPath}", 1);
                    File.WriteAllBytes(UserEntriesPath, HelperMethods.GetResourceBytes(Main.CurrAsm, "UserEntries.txt"));
                }
            }
        }
    }
}