using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PaymentSettingsScreen : MonoBehaviour
{
    public Button backBtn;
    public Text cardHolderNameTxt;
    public Text cardNumTxt;
    public Text expiryDateTxt;
    public Text cvcTxt;
    public Button addCardBtn;
    public Button saveBtn;
    public Image onSp;
    public Image offSp;

    void Start()
    {
        backBtn.onClick.AddListener(() => BackBtnClick());
        saveBtn.onClick.AddListener(() => SaveBtnClick());
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
        ScreenManager.instance.EnableDisablePaymentSettingsScreen(false);
    }

    public void SaveBtnClick()
    {
        ScreenManager.instance.EnableDisablePaymentSettingsScreen(false);
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
