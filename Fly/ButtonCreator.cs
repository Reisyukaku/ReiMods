using MelonLoader;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Fly
{
    public class ButtonCreator
    {
        public string Name;
        public string Text;
        public string ToolTip;

        public void CreateOnSocialCtxt(string parent, Vector2 offset, System.Action butAction)
        {
            //Get Menu
            Transform quickMenuSoc = GameObject.Find("Screens").transform; //QuickMenuSocial.field_Internal_Static_QuickMenuSocial_0.transform;

            // Clone of a standard button
            Transform butTransform = UnityEngine.Object.Instantiate(quickMenuSoc.Find("UserInfo/User Panel/Playlists/PlaylistsButton").gameObject).transform;

            // Set internal name of button
            butTransform.name = Name;

            // Set button's parent to quick menu
            butTransform.SetParent(quickMenuSoc.Find(parent), false);

            // Set button's text
            butTransform.GetComponentInChildren<Text>().text = Text;

            // Set position of new button based on existing menu buttons
            butTransform.localPosition = new Vector3(butTransform.localPosition.x + offset.x, butTransform.localPosition.y + offset.y, butTransform.localPosition.z);
            butTransform.transform.Find("Image/Icon_New").transform.gameObject.SetActive(false);

            // Make it so the button does what we want
            butTransform.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            butTransform.GetComponent<Button>().onClick.AddListener(butAction);

            // enable it just in case
            butTransform.gameObject.SetActive(true);
        }

        public void CreateOnPlayerCtxt(string parent, Vector2 offset, System.Action butAction)
        {
            //Get Menu
            Transform quickMenu = QuickMenu.prop_QuickMenu_0.transform;

            // Clone of a standard button
            Transform butTransform = UnityEngine.Object.Instantiate(quickMenu.Find("CameraMenu/BackButton").gameObject).transform;

            // Set internal name of button
            butTransform.name = Name;

            // Set button's parent to quick menu
            butTransform.SetParent(quickMenu.Find(parent), false);

            // Set button's text
            butTransform.GetComponentInChildren<Text>().text = Text;
            butTransform.GetComponent<UiTooltip>().text = ToolTip;
            butTransform.GetComponent<UiTooltip>().alternateText = ToolTip;

            // Set position of new button based on existing menu buttons
            float buttonWidth = quickMenu.Find("UserInteractMenu/ForceLogoutButton").localPosition.x - quickMenu.Find("UserInteractMenu/BanButton").localPosition.x;
            float buttonHeight = quickMenu.Find("UserInteractMenu/ForceLogoutButton").localPosition.x - quickMenu.Find("UserInteractMenu/BanButton").localPosition.x;

            butTransform.localPosition = new Vector3(butTransform.localPosition.x + buttonWidth * offset.x, butTransform.localPosition.y + buttonHeight * offset.y, butTransform.localPosition.z);
            MelonModLogger.Log("button: " + butTransform.localPosition);

            // Make it so the button does what we want
            butTransform.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            butTransform.GetComponent<Button>().onClick.AddListener(butAction);

            // enable it just in case
            butTransform.gameObject.SetActive(true);
        }
    }
}
