using BLRPC.Melon;
using BLRPC.Presence.Managers;
using BLRPC.Presence.Variables;
using HarmonyLib;
using NEP.DOOMLAB.Entities;
using SLZ.AI;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedParameter.Global

namespace BLRPC.Presence.Patching
{
    public static class NPCDeathCounter
    {
        [HarmonyPatch(typeof(AIBrain), "OnDeath")]
        public class AIBrain_OnDeath
        {
            public static void Postfix(AIBrain __instance)
            {
                if (Main.IsQuest || Main.DiscordClosed) return;
                if (Preferences.DetailsMode.Value == DetailsMode.NPCDeaths)
                {
                    UpdateCounter();
                }
            }
        }
        
        [HarmonyPatch(typeof(Mobj), "Kill")]
        public class Mobj_OnDeath
        {
            public static void Postfix(Mobj __instance)
            {
                if (Main.IsQuest || Main.DiscordClosed) return;
                if (Preferences.DetailsMode.Value == DetailsMode.NPCDeaths && Preferences.CountDoomlabDeaths.Value)
                {
                    if (!__instance.flags.HasFlag(MobjFlags.MF_COUNTKILL)) return;
                    UpdateCounter();
                }
            }
        }
        
        public static int Counter;
        private static void UpdateCounter()
        {
            Counter += 1;
            ModConsole.Msg($"NPC died, new death count is {Counter}", 1);
            GlobalVariables.Details = $"NPC Deaths: {Counter}";
            RpcManager.Instance.SetRpc(GlobalVariables.Details, GlobalVariables.Status, GlobalVariables.LargeImageKey, GlobalVariables.LargeImageText, GlobalVariables.SmallImageKey, GlobalVariables.SmallImageText);
        }
    }
}