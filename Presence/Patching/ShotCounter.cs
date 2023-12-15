using BLRPC.Melon;
using BLRPC.Presence.Managers;
using BLRPC.Presence.Variables;
using HarmonyLib;
using SLZ.Props;
using SLZ.Props.Weapons;

namespace BLRPC.Presence.Patching
{
    public static class ShotCounter
    {
        [HarmonyPatch(typeof(Gun), "OnFire")]
        public class Gun_Fire
        {
            public static void Postfix(Gun __instance)
            {
                if (Main.IsQuest || Main.DiscordClosed) return;
                if (Preferences.DetailsMode.Value == DetailsMode.GunShots)
                {
                    if (__instance.GetComponent<SpawnGun>()) return;
                    UpdateCounter();
                }
            }
        }
        public static int Counter;
        private static void UpdateCounter()
        {
            Counter += 1;
            ModConsole.Msg($"Gun fired, new shot count is {Counter}", 1);
            GlobalVariables.Details = $"Gun Shots Fired: {Counter}";
            RpcManager.Instance.SetRpc(GlobalVariables.Details, GlobalVariables.Status, GlobalVariables.LargeImageKey, GlobalVariables.LargeImageText, GlobalVariables.SmallImageKey, GlobalVariables.SmallImageText);
        }
    }
}