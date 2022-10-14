using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DesigningScreen : MonoBehaviour
{
    public Button notificationBtn;
    public Button previewBtn;

    void Start()
    {
        notificationBtn.onClick.AddListener(() => NotificationBtnClicked());
        previewBtn.onClick.AddListener(() => PreviewBtnClicked());
    }

    private void OnEnable()
    {
        //ScreenManager.instance.FadeScreenPanel();
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void NotificationBtnClicked()
    {
        ScreenManager.instance.EnableDisableNotificationScreen(true);
    }

    public void PreviewBtnClicked()
    {
        ScreenManager.instance.EnableDisablePreviewScreen(true);
    }

    public void backToHome()
    {
        ScreenManager.instance.homeScreenRef.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
        this.transform.parent.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
}
