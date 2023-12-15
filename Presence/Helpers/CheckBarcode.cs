using BoneLib;

namespace BLRPC.Presence.Helpers
{
    public static class CheckBarcode
    {
        public static string CheckAvatar(string barcode)
        {
            switch (barcode)
            {
                case CommonBarcodes.Avatars.Heavy:
                    return "heavy";
                case CommonBarcodes.Avatars.Fast:
                    return "fast";
                case CommonBarcodes.Avatars.Short:
                    return "short";
                case CommonBarcodes.Avatars.Tall:
                    return "tall";
                case CommonBarcodes.Avatars.Strong:
                    return "strong";
                case CommonBarcodes.Avatars.Light:
                    return "light";
                case CommonBarcodes.Avatars.Jimmy:
                    return "jimmy";
                case CommonBarcodes.Avatars.FordBW:
                    return "ford";
                case CommonBarcodes.Avatars.FordBL:
                    return "ford";
                case CommonBarcodes.Avatars.PeasantFemaleA:
                    return "peasantfemalea";
                case CommonBarcodes.Avatars.PeasantFemaleB:
                    return "peasantfemaleb";
                case CommonBarcodes.Avatars.PeasantFemaleC:
                    return "peasantfemalec";
                case CommonBarcodes.Avatars.PeasantMaleA:
                    return "peasantmalea";
                case CommonBarcodes.Avatars.PeasantMaleB:
                    return "peasantmaleb";
                case CommonBarcodes.Avatars.PeasantMaleC:
                    return "peasantmalec";
                case CommonBarcodes.Avatars.Nullbody:
                    return "nullbody";
                case CommonBarcodes.Avatars.Skeleton:
                    return "skeleton";
                case CommonBarcodes.Avatars.SecurityGuard:
                    return "securityguard";
                case CommonBarcodes.Avatars.DuckSeasonDog:
                    return "duckseasondog";
                case CommonBarcodes.Avatars.PolyBlank:
                    return "polyblank";
                case CommonBarcodes.Avatars.PolyDebugger:
                    return "polyblank";
                default:
                    return "moddedavatar";
            }
        }
        public static string CheckMap(string barcode)
        {
            switch (barcode)
            {
                case CommonBarcodes.Maps.MainMenu:
                    return "mainmenu";
                case CommonBarcodes.Maps.Descent:
                    return "descent";
                case CommonBarcodes.Maps.BLHub:
                    return "blhub";
                case CommonBarcodes.Maps.LongRun:
                    return "longrun";
                case CommonBarcodes.Maps.MineDive:
                    return "minedive";
                case CommonBarcodes.Maps.BigAnomaly:
                    return "biganomaly";
                case CommonBarcodes.Maps.StreetPuncher:
                    return "streetpuncher";
                case CommonBarcodes.Maps.SprintBridge:
                    return "sprintbridge";
                case CommonBarcodes.Maps.MagmaGate:
                    return "magmagate";
                case CommonBarcodes.Maps.Moonbase:
                    return "moonbase";
                case CommonBarcodes.Maps.MonogonMotorway:
                    return "monogonmotorway";
                case CommonBarcodes.Maps.PillarClimb:
                    return "pillarclimb";
                case CommonBarcodes.Maps.BigAnomaly2:
                    return "biganomaly2";
                case CommonBarcodes.Maps.Ascent:
                    return "ascent";
                case CommonBarcodes.Maps.Home:
                    return "home";
                case CommonBarcodes.Maps.VoidG114:
                    return "voidg114";
                case CommonBarcodes.Maps.Baseline:
                    return "baseline";
                case CommonBarcodes.Maps.BigBoneBowling:
                    return "bigbonebowling";
                case CommonBarcodes.Maps.DropPit:
                    return "droppit";
                case CommonBarcodes.Maps.DungeonWarrior:
                    return "dungeonwarrior";
                case CommonBarcodes.Maps.FantasyArena:
                    return "fantasyarena";
                case CommonBarcodes.Maps.GunRange:
                    return "gunrange";
                case CommonBarcodes.Maps.HalfwayPark:
                    return "halfwaypark";
                case CommonBarcodes.Maps.Holochamber:
                    return "holochamber";
                case CommonBarcodes.Maps.MuseumBasement:
                    return "museumbasement";
                case CommonBarcodes.Maps.NeonParkour:
                    return "neonparkour";
                case CommonBarcodes.Maps.NeonTrial:
                    return "neontrial";
                case CommonBarcodes.Maps.Rooftops:
                    return "rooftops";
                case CommonBarcodes.Maps.TunnelTipper:
                    return "tunneltipper";
                case CommonBarcodes.Maps.Tuscany:
                    return "tuscany";
                case CommonBarcodes.Maps.ContainerYard:
                    return "containeryard";
                case CommonBarcodes.Maps.Mirror:
                    return "mirror";
                default:
                    return "moddedmap";
            }
        }
    }
}