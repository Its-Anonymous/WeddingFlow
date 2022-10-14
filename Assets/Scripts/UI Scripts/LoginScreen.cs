using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoginScreen : MonoBehaviour
{
    public Button backBtn;
    public Button loginBtn;
    public Button signUpBtn;
    public GameObject flowers;
    public GameObject userInfoPanel;
    public float offsetPos;
    public float resetPos;
    Tweener flowerTween;


    void Start()
    {
        playFloweranim();
        backBtn.onClick.AddListener(() => BackBtnClicked());
       // loginBtn.onClick.AddListener(() => StartCoroutine(_NextScreenCor()));
        signUpBtn.onClick.AddListener(() => SignUpBtnClicked());
    }

    private void OnEnable()
    {
        ScreenManager.instance.FadeScreenPanel();
        flowerTween.Play();
        otherAnims();
    }

    private void OnDisable()
    {
        flowerTween.Pause();
        CancelInvoke();
        userInfoPanel.transform.DOLocalMoveY(resetPos, 0f);
    }

    void otherAnims()
    {
        userInfoPanel.transform.DOLocalMoveY(offsetPos, 1f);
        userInfoPanel.gameObject.GetComponent<Image>().DOFade(0, 1f);
    }

    void playFloweranim()
    {
        foreach (Transform child in flowers.transform)
        {
           flowerTween = child.transform.DOLocalRotate(new Vector3(0, 0, 20), 3f).SetLoops(-1, LoopType.Yoyo);
        }
    }

    IEnumerator _NextScreenCor()
    {
        yield return new WaitForSeconds(0.5f);
        ScreenManager.instance.EnableDisableHomeScreen(true);
        ScreenManager.instance.EnableDisableLoginScreen(false);
        ScreenManager.instance.EnableDisablePreLoginScreen(false);
    }

    public void SignUpBtnClicked()
    {
        ScreenManager.instance.EnableDisableSignUpScreen(true);
    }

    public void BackBtnClicked()
    {
        ScreenManager.instance.EnableDisableLoginScreen(false);
    }
}
