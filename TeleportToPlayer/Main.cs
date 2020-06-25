using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using Unity;
using UnityEngine;
using Harmony;
using UnityEngine.SceneManagement;
using UnhollowerBaseLib;
using UnityEngine.Experimental.PlayerLoop;
using VRC.Core;
using VRC;
using System.Reflection;
using System.Runtime.InteropServices;
using VRCSDK2;
using Il2CppSystem;
using IntPtr = System.IntPtr;
using ConsoleColor = System.ConsoleColor;
using UnhollowerRuntimeLib;
using IL2CPP = UnhollowerBaseLib.IL2CPP;
using UnityEngine.UI;
using VRC.UI;

namespace TeleportToPlayer
{
    internal class teleport : MelonMod
    {

        public static Player GetPlayer(string UserID)
        {
            var Players = PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0;
            Player FoundPlayer = null;
            for (int i = 0; i < Players.Count; i++)
            {
                var player = Players[i];
                if (player.field_Private_APIUser_0.id == UserID)
                {
                    FoundPlayer = player;
                }
            }

            return FoundPlayer;
        }

        public override void OnApplicationStart()
        {
            MelonModLogger.Log("Teleport to Players mod started");
        }

        public override void VRChat_OnUiManagerInit()
        {
            ButtonCreator socBut = new ButtonCreator();
            socBut.Name = "tpSocialMenu";
            socBut.Text = "<color=white>Teleport to Player</color>";
            socBut.ToolTip = "Teleports you to the selected player";
            socBut.CreateOnSocialCtxt("UserInfo/User Panel/Playlists", new Vector2(0, 76.0f), new System.Action(() =>
            {
                MelonModLogger.Log("[Social Menu] Teleporting to player");

                //Get Players
                VRCPlayer player = VRCPlayer.field_Internal_Static_VRCPlayer_0;
                var targetPlayerId = GameObject.Find("Screens").transform.Find("UserInfo").transform.GetComponentInChildren<PageUserInfo>().user.id;

                //Disallow teleport to self
                if (player.prop_Player_0.field_Private_APIUser_0.id == targetPlayerId) return;

                //Get target players Player object
                Player targetPlayer = GetPlayer(targetPlayerId);
                if (targetPlayer == null) return;

                //Apply position
                player.transform.position = targetPlayer.transform.position;

                VRCUiManager.prop_VRCUiManager_0.Method_Public_Void_Boolean_2(false);
            }));

            ButtonCreator playBut = new ButtonCreator();
            playBut.Name = "tpPlayerMenu";
            playBut.Text = "<color=white>Teleport to Player</color>";
            playBut.ToolTip = "Teleports you to the selected player";
            playBut.CreateOnPlayerCtxt("UserInteractMenu", Vector2.zero, new System.Action(() =>
            {
                MelonModLogger.Log("[Player Menu] Teleporting to player");

                //Get players
                VRCPlayer player = VRCPlayer.field_Internal_Static_VRCPlayer_0;
                APIUser target = QuickMenu.prop_QuickMenu_0.field_Private_APIUser_0;

                //Disallow teleport to self
                if (player.prop_Player_0.field_Private_APIUser_0.id == target.id) return;

                //Get target players Player object
                Player targetPlayer = GetPlayer(target.id);
                if (targetPlayer == null) return;

                //Apply position
                player.transform.position = targetPlayer.transform.position;
            }));
        }
    }
}