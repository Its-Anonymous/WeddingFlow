using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SelectBGAndParticipantsScreen : MonoBehaviour
{
    public Button notificationBtn;
    public Button startDesigningBtn;
    public Button addParticipantButtons;
    public GameObject addParticipantPopup;

    void Start()
    {
        notificationBtn.onClick.AddListener(() => NotificationBtnClicked());
        startDesigningBtn.onClick.AddListener(() => StartDesigningBtnClicked());
        addParticipantButtons.onClick.AddListener(() => addParticipantButton());
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

    public void StartDesigningBtnClicked()
    {
        ScreenManager.instance.loadingScreen.GetComponent<sceneChangeController>().loadconfig(true);
    }

public void addParticipantButton()
    {
        addParticipantPopup.SetActive(true);
    }
}
