using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{
    public Button backBtn;
    public Button changePasswordBtn;
    public Button paymentSettingsBtn;
    public Image onSp;
    public Image offSp;

    void Start()
    {
        backBtn.onClick.AddListener(() => BackBtnClick());
        changePasswordBtn.onClick.AddListener(() => ChangePasswordBtnClick());
        paymentSettingsBtn.onClick.AddListener(() => PaymentSettingsBtnClick());
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
        ScreenManager.instance.EnableDisableSettingsScreen(false);
    }

    public void ChangePasswordBtnClick()
    {
        
    }

    public void PaymentSettingsBtnClick()
    {
        ScreenManager.instance.EnableDisablePaymentSettingsScreen(true);
    }

    public void ToggleOn()
    {
        onSp.gameObject.SetActive(true);
        offSp.gameObject.SetActive(false);
    }

    public void ToggleOff()
    {
        offSp.gameObject.SetActive(true);
        onSp.gameObject.SetActive(false);
    }

    void Update()
    {

    }
}
