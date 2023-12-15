using System.Collections;
using BLRPC.Presence.Helpers;
using BLRPC.Presence.Variables;
using BoneLib;
using UnityEngine;

namespace BLRPC.Presence.Managers
{
    internal static class AvatarManager
    {
        public static IEnumerator Update()
        {
            while (LevelManager.LevelLoaded)
            {
                UpdateAvatar();
                yield return new WaitForSeconds(10);
                
                while (!LevelManager.LevelLoaded)
                {
                    yield return null;
                }
            }
        }

        private static void UpdateAvatar()
        {
            var rigManager = Player.rigManager;
            var avatar = rigManager.AvatarCrate.Crate;
            GlobalVariables.SmallImageKey = CheckBarcode.CheckAvatar(avatar.Barcode);
            GlobalVariables.SmallImageText = avatar.Title;
            RpcManager.Instance.SetRpc(GlobalVariables.Details, GlobalVariables.Status, GlobalVariables.LargeImageKey, GlobalVariables.LargeImageText, GlobalVariables.SmallImageKey, GlobalVariables.SmallImageText);
        }
    }
}