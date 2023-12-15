using BLRPC.Melon;
using BLRPC.Presence.Managers;
using BLRPC.Presence.Variables;
using HarmonyLib;
using SLZ.Props;
using SLZ.Props.Weapons;

namespace BLRPC.Presence.Patching
{
    public static class SpawnCounter
    {
        [HarmonyPatch(typeof(SpawnGun), "OnFire")]
        public class SpawnGun_Spawn
        {
            public static void Postfix(Gun __instance)
            {
                if (Main.IsQuest || Main.DiscordClosed) return;
                if (Preferences.DetailsMode.Value == DetailsMode.SpawnablesPlaced)
                {
                    UpdateCounter();
                }
            }
        }

        public static int Counter;
        private static void UpdateCounter()
        {
            Counter += 1;
            ModConsole.Msg($"Spawnable placed, new spawn count is {Counter}", 1);
            GlobalVariables.Details = $"Objects Spawned: {Counter}";
            RpcManager.Instance.SetRpc(GlobalVariables.Details, GlobalVariables.Status, GlobalVariables.LargeImageKey, GlobalVariables.LargeImageText, GlobalVariables.SmallImageKey, GlobalVariables.SmallImageText);
        }
    }
}