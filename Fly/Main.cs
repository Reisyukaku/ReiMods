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

namespace Fly
{
    internal class fly : MelonMod
    {
        private bool isFlying = false;

        public override void OnApplicationStart()
        {
            MelonModLogger.Log("Flying mod started");
        }

        public override void VRChat_OnUiManagerInit()
        {
            ButtonCreator socBut = new ButtonCreator();
            socBut.Name = "flySocialMenu";
            socBut.Text = "<color=white>Fly Toggle</color>";
            socBut.ToolTip = "Fly/noclip";
            socBut.CreateOnSocialCtxt("UserInfo/User Panel/Playlists", Vector2.zero, new System.Action(() =>
            {
                MelonModLogger.Log("[Social Menu] Toggling flying");

                //Get Players
                VRCPlayer player = VRCPlayer.field_Internal_Static_VRCPlayer_0;
                //TODO
            }));
        }
    }
}
