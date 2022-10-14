using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreen : MonoBehaviour
{
    [Header("References")]
    public Button notificationBtn;
    public Button continueBtn;
    public Button favViewAllBtn;
    public Button recViewAllBtn;
    public Button addBtn;
    public Text[] continueTextGlow;
    public GameObject upperPanel;
    [Header("Tween offsets")]
    public float addBtnOffsetPos;
    public float addBtnResetPos;
    public float offsetPos;
    public float resetPos;

    void Start()
    {
        notificationBtn.onClick.AddListener(() => NotificationBtnClicked());
        continueBtn.onClick.AddListener(() => ContinueBtnClicked());
        favViewAllBtn.onClick.AddListener(() => FavViewAllBtnClicked());
        recViewAllBtn.onClick.AddListener(() => RecViewAllBtnClicked());
        addBtn.onClick.AddListener(() => AddBtnClicked());
    }

    private void OnEnable()
    {
        ScreenManager.instance.FadeScreenPanel();
        addBtn.transform.DOLocalMoveY(addBtnOffsetPos, 1f);
        upperPanel.transform.DOLocalMoveY(offsetPos, 1f);
    }

    private void OnDisable()
    {
        CancelInvoke();
        addBtn.transform.DOLocalMoveY(addBtnResetPos, 0f);
        upperPanel.transform.DOLocalMoveY(resetPos, 0f);
    }

    public void NotificationBtnClicked()
    {
        ScreenManager.instance.EnableDisableNotificationScreen(true);
    }

    public void ContinueBtnClicked()
    {
        //ScreenManager.instance.EnableDisableDesignScreen(true);
        //ScreenManager.instance.EnableDisableDesigningScreen(true);
    }

    public void FavViewAllBtnClicked()
    {
        ScreenManager.instance.EnableDisableFavoritesScreen(true);
    }

    public void RecViewAllBtnClicked()
    {
        ScreenManager.instance.EnableDisableMyDesignsScreen(true);
    }

    public void AddBtnClicked()
    {
        ScreenManager.instance.EnableDisableDesignScreen(true);
        ScreenManager.instance.EnableDisableSelectBGAndParticipantsScreen(true);
    }  

    void Update()
    {
        
    }
}
