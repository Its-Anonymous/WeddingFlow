using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PreviewScreen : MonoBehaviour
{
    public Button backBtn;
    public Button notificationBtn;
    public Button favoriteBtn;
    public Button shareBtn;
    public Button backToEditingBtn;
    public Button saveAndExportBtn;

    void Start()
    {
        backBtn.onClick.AddListener(() => BackBtnClick());
        notificationBtn.onClick.AddListener(() => NotificationBtnClicked());
        backToEditingBtn.onClick.AddListener(() => BackToEditingBtnClicked());
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
        ScreenManager.instance.EnableDisablePreviewScreen(false);
    }

    public void NotificationBtnClicked()
    {
        ScreenManager.instance.EnableDisableNotificationScreen(true);
    }

    public void BackToEditingBtnClicked()
    {
        ScreenManager.instance.EnableDisableSelectBGAndParticipantsScreen(true);
        ScreenManager.instance.EnableDisablePreviewScreen(false);
        ScreenManager.instance.EnableDisableDesigningScreen(false);

    }

    void Update()
    {

    }
}
