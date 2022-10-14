using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public class SignUpScreen : MonoBehaviour
{
    public Button backBtn;
    public Button signUpBtn;
    public GameObject flowers;
    public GameObject userInfoPanel;
    public RawImage userProfileImage;
    public float offsetPos;
    public float resetPos;
    Tweener flowerTween;
    //public ToggleGroup toggleGroup;
    //Toggle toggle;
    private void OnEnable()
    {
        flowerTween.Play();
        userInfoPanel.transform.DOLocalMoveY(offsetPos, 1f);
    }
    private void OnDisable()
    {
        flowerTween.Pause();
        userInfoPanel.transform.DOLocalMoveY(resetPos, 0f);
        CancelInvoke();
    }

    void playFloweranim()
    {
        foreach (Transform child in flowers.transform)
        {
           flowerTween = child.transform.DOLocalRotate(new Vector3(0, 0, 20), 3f).SetLoops(-1, LoopType.Yoyo);
        }
    }

    void Start()
    {
        playFloweranim();
        backBtn.onClick.AddListener(() => BackBtnClicked());
       // signUpBtn.onClick.AddListener(() => SignUpBtnClicked());
        //toggleGroup = GetComponent<ToggleGroup>();
    }

    public void SignUpBtnClicked()
    {
        //toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        //Debug.Log(toggle.name + "--" + toggle.GetComponentInChildren<Text>().text);
        //EmailLogin.instance.GendreStringTxt=toggle.GetComponentInChildren<Text>().text;
        //Debug.Log(EmailLogin.instance.GendreStringTxt);
        ScreenManager.instance.EnableDisableHomeScreen(true);
        ScreenManager.instance.EnableDisableSignUpScreen(false);
        ScreenManager.instance.EnableDisableLoginScreen(false);
        ScreenManager.instance.EnableDisablePreLoginScreen(false);
    }

    public void BackBtnClicked()
    {
        ScreenManager.instance.EnableDisableSignUpScreen(false);
    }



}
