using BLRPC.Melon;
using SLZ.Marrow.Warehouse;

namespace BLRPC.Presence.Helpers
{
    public static class CheckPallets
    {
        public static int GetPalletCount()
        {
            ModConsole.Msg("Getting pallet count", 1);
            var count = AssetWarehouse.Instance.GetPallets().Count;
            ModConsole.Msg($"Pallet count is {count}", 1);
            return count;
        }
    }
}