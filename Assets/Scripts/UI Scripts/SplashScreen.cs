using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SplashScreen : MonoBehaviour
{
    private float waitingTime = 6f;
    public Image bgImage;
    public Image logoImage;
    public Image lodingBarFillImage;
    public Image[] flowers;
    Tweener flowerTween;

    void Start()
    {
        flowerAnimation();
        bgImage.DOFade(0f, 1f);
    }

    private void OnEnable()
    {
        flowerTween.Play();
        LogoAnimation();
        StartCoroutine(LoadingBarAnimation());
    }

    private void OnDisable()
    {
        CancelInvoke();
        flowerTween.Pause();
    }

    IEnumerator LoadingBarAnimation()
    {
        yield return new WaitForSeconds(waitingTime);
        NextScreen();
    }

    public void NextScreen()
    {
        var a = ScreenManager.instance.preLoginScreenRef.GetComponent<Image>().color;
        a.a = 0f;                                                                               // set alpha to 0 
        ScreenManager.instance.preLoginScreenRef.GetComponent<Image>().color = a;
        ScreenManager.instance.EnableDisablePreLoginScreen(true);
        ScreenManager.instance.preLoginScreenRef.GetComponent<Image>().DOFade(255, 1f);

        for(int i = 0; i<4; i++)
        {
            flowers[i].DOFade(0f,0.4f);
        }
        logoImage.DOFade(0f, 0.4f);
        ScreenManager.instance.splashScreenRef.GetComponent<Image>().DOFade(0f, 0.4f).OnComplete(() =>
        {
            ScreenManager.instance.EnableDisableSplashScreen(false);
            ScreenManager.instance.EnableDisablePreLoginScreen(true);
        });
    }

    #region Logo Animation

    public void LogoAnimation()
    {
        logoImage.DOFade(1f, 4f).SetDelay(0.4f).SetEase(Ease.InCirc);
    }

    void flowerAnimation()
    {
        foreach (var child in flowers)
        {
           flowerTween = child.transform.DOLocalRotate(new Vector3(0, 0, 20), 3f).SetLoops(-1, LoopType.Yoyo);
        }
    }
    #endregion
    void Update()
    {
        
    }
}
