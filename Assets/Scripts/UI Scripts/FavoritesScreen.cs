using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FavoritesScreen : MonoBehaviour
{
    public Button backBtn;
    public Button notificationBtn;

    void Start()
    {
        backBtn.onClick.AddListener(() => BackBtnClick());
        notificationBtn.onClick.AddListener(() => NotificationBtnClicked());
    }

    private void OnEnable()
    {
        //ScreenManager.instance.FadeScreenPanel();
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void BackBtnClick()
    {
        ScreenManager.instance.EnableDisableFavoritesScreen(false);
    }

    public void NotificationBtnClicked()
    {
        ScreenManager.instance.EnableDisableNotificationScreen(true);
    }

    void Update()
    {

    }
}
