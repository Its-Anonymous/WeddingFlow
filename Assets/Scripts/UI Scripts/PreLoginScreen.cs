using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PreLoginScreen : MonoBehaviour
{
    public Button guestBtn;
    public Button facebookBtn;
    public Button appleBtn;
    public Button signUpBtn;
    public GameObject flowers;

    Tweener flowerTween;

    private void OnEnable()
    {
        flowerTween.Play();
    }

    private void OnDisable()
    {
        CancelInvoke();
        flowerTween.Pause();
    }

    void Start()
    {
        guestBtn.onClick.AddListener(() => GuestBtnClicked());
        facebookBtn.onClick.AddListener(() => StartCoroutine(_NextScreenCor()));
        appleBtn.onClick.AddListener(() => StartCoroutine(_NextScreenCor()));
        signUpBtn.onClick.AddListener(() => SignUpBtnClicked());

        foreach(Transform child in flowers.transform)
        {
       flowerTween = child.transform.DOLocalRotate(new Vector3(0, 0, 20), 3f).SetLoops(-1, LoopType.Yoyo);
        }
    }

    public void GuestBtnClicked()
    {
        ScreenManager.instance.EnableDisableLoginScreen(true);
    }

    public void FacebookBtnClicked()
    {
        //AgreementPopUpScreen.instance.AgreementPopUp();
    }

    public void AppleBtnClicked()
    {
        //AgreementPopUpScreen.instance.AgreementPopUp();
    }

    public void SignUpBtnClicked()
    {
        ScreenManager.instance.EnableDisableSignUpScreen(true);
    }

    IEnumerator _NextScreenCor()
    {
        yield return new WaitForSeconds(0.5f);
        ScreenManager.instance.EnableDisableHomeScreen(true);
        ScreenManager.instance.EnableDisablePreLoginScreen(false);   
    }

    void Update()
    {
        
    }
}
