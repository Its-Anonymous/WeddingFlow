using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePopUp : MonoBehaviour
{
    public Button okBtn;

    public void ShowMessagePanelText(string text)
    {
        EnableDisableShowMessagePanel(true);
        this.gameObject.GetComponentInChildren<Text>().text = text;
    }

    public void EnableDisableShowMessagePanel(bool status)
    {
        this.gameObject.SetActive(status);
    }

    public void DisableScreens()
    {
        ScreenManager.instance.EnableDisableLoginScreen(true);
    }
}
