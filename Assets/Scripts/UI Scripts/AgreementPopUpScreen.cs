using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AgreementPopUpScreen : MonoBehaviour
{
    public static AgreementPopUpScreen instance;

    public Button rejectBtn;
    public Button acceptBtn;
    public Toggle TCToggle;
    public Toggle PPToggle;

    public bool isClicked = false;
    public GameObject fadeScreeen;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rejectBtn.onClick.AddListener(() => RejectBtnClicked());
        acceptBtn.onClick.AddListener(() => AcceptBtnClicked());
    }

    public void AgreementPopUp()
    {
        if (!isClicked)
        {
            Debug.Log(isClicked);
            isClicked = true;
            fadeScreeen.SetActive(true);
            EnableDisableAgreementPopUp(true);
        }
        else if (isClicked)
        {
            Debug.Log(isClicked);
            isClicked = false;
            fadeScreeen.SetActive(false);
            EnableDisableAgreementPopUp(false);
        }
    }

    public void Exception()
    {
        if(!TCToggle.isOn || !PPToggle.isOn)
        {
            TCToggle.GetComponentInChildren<Text>().color = Color.red;
            TCToggle.GetComponentInChildren<Text>().color = Color.red;
            acceptBtn.interactable = false;
        }
        return;
    }

    public void RejectBtnClicked()
    {
        AgreementPopUp();
    }

    public void AcceptBtnClicked()
    {
        Exception();
        AgreementPopUp();
        ScreenManager.instance.EnableDisablePreLoginScreen(false);
        ScreenManager.instance.EnableDisableHomeScreen(true);
        ScreenManager.instance.EnableDisableSidePanelScreen(true);
    }

    public void EnableDisableAgreementPopUp(bool status)
    {
        this.gameObject.SetActive(status);
    }

    void Update()
    {
        
    }
}
