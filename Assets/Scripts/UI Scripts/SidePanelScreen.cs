using UnityEngine;
using System.Collections.Generic;

public class SidePanelScreen : MonoBehaviour
{

    public static SidePanelScreen instance;
    public GameObject canvas;

    private void Awake()
    {
        instance = this;
    }

    public void EditProfileBtnClicked()
    {
        ScreenManager.instance.EnableDisableEditProfileScreen(true);
    }

    public void HomeScreenBtnClicked()
    {
        ScreenManager.instance.EnableDisableDesignScreen(false);
        ScreenManager.instance.EnableDisableDesigningScreen(false);
        ScreenManager.instance.EnableDisablePreviewScreen(false);
    }

    public void MyDesignsScreenBtnClicked()
    {
        ScreenManager.instance.EnableDisableMyDesignsScreen(true);

    }

    public void FavoritesScreenBtnClicked()
    {
        ScreenManager.instance.EnableDisableFavoritesScreen(true);

    }

    public void SettingsScreenBtnClicked()
    {
        ScreenManager.instance.EnableDisableSettingsScreen(true);

    }

    public void LogoutBtnClicked()
    {
        int childrens = canvas.transform.childCount;
        for (int i = 0; i < childrens; i++)
        {
           if(i != 0)
            {
                canvas.transform.GetChild(i).gameObject.SetActive(false);
            }
            if (i == 0)
            {
                canvas.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (i == 9)
            {
                canvas.transform.GetChild(9).gameObject.SetActive(true);
            }
        }
    }
}
