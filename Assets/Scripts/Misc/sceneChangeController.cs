using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class sceneChangeController : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image logo_back;
    public Image logo_text;
    public Text logo_subtext;

    AsyncOperation load;

    private void OnEnable()
    {
        playAnim();
        StartCoroutine(changeText());
    }

    private void Update()
    {
       
    }

    public void loadconfig(bool loadconfigg)
    {
        StartCoroutine(loadConfigurator(loadconfigg));
    }

     IEnumerator loadConfigurator(bool loadConfig) // true to change to config and false for ui screen
    {
        Screen.orientation = ScreenOrientation.Portrait;
        loadingScreen.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.3f);
        if (loadConfig)
        {
            load = SceneManager.LoadSceneAsync("Configurator");
            load.allowSceneActivation = false;
            yield return new WaitForSeconds(4f);
            Screen.orientation = ScreenOrientation.Landscape;
            load.allowSceneActivation = true;
        }
        if(!loadConfig)
        {
            load = SceneManager.LoadSceneAsync("UiScene");
            load.allowSceneActivation = false;
            yield return new WaitForSeconds(4f);
            Screen.orientation = ScreenOrientation.Portrait;
            load.allowSceneActivation = true;
        }
        while(!load.isDone)
        {
            yield return null;
        }
    }
    void playAnim()
    {
        logo_back.transform.DOScale(1.1f, 1.7f).SetLoops(-1, LoopType.Yoyo).OnComplete(() =>
        {
                playAnim();
        }).SetAutoKill(false);
    }

    IEnumerator changeText()
    {
        yield return new WaitForSeconds(0.5f);
        logo_subtext.text = "Loading";
        yield return new WaitForSeconds(0.5f);
        logo_subtext.text = "Loading.";
        yield return new WaitForSeconds(0.5f);
        logo_subtext.text = "Loading..";
        yield return new WaitForSeconds(0.5f);
        logo_subtext.text = "Loading...";
        StartCoroutine(changeText());
    }
}
