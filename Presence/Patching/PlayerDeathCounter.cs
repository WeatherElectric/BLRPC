using BLRPC.Melon;
using BLRPC.Presence.Managers;
using BLRPC.Presence.Variables;
using HarmonyLib;

namespace BLRPC.Presence.Patching
{
    public static class PlayerDeathCounter
    {
        [HarmonyPatch(typeof(Player_Health), "Death")]
        public class PlayerDeath
        {
            public static void Postfix(Player_Health __instance)
            {
                if (Main.IsQuest || Main.DiscordClosed) return;
                if (Preferences.DetailsMode.Value == DetailsMode.PlayerDeaths)
                {
                    UpdateCounter();
                }
            }
        }
        
        public static int Counter;
        
        private static void UpdateCounter()
        {
            Counter += 1;
            ModConsole.Msg($"Playerdied, new death count is {Counter}", 1);
            GlobalVariables.Details = $"Player Deaths: {Counter}";
            RpcManager.Instance.SetRpc(GlobalVariables.Details, GlobalVariables.Status, GlobalVariables.LargeImageKey, GlobalVariables.LargeImageText, GlobalVariables.SmallImageKey, GlobalVariables.SmallImageText);
        }
        
    }
}