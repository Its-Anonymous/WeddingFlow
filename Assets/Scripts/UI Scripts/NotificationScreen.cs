using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class NotificationScreen : MonoBehaviour
{
    public Button backBtn;

    void Start()
    {
        backBtn.onClick.AddListener(() => BackBtnClick());
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
        ScreenManager.instance.EnableDisableNotificationScreen(false);
    }

    void Update()
    {

    }
}
