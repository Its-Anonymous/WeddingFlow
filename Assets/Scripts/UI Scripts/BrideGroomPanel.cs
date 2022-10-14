using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BrideGroomPanel : MonoBehaviour
{
    public Text titleText;
    public Button forwardButton;
    public Button backwardButton;
    public GameObject bridePanel;
    public GameObject groomPanel;

    public bool bridePanelEnabled = true;

    void Start()
    {
        forwardButton.onClick.AddListener(() => StartCoroutine(changePanel()));
        backwardButton.onClick.AddListener(() => StartCoroutine(changePanel()));
    }
    IEnumerator changePanel()
    {
        if (!bridePanelEnabled)
        {
            titleText.text = "Bride";
            groomPanel.SetActive(false);
            bridePanel.SetActive(true);
            bridePanelEnabled = true;
        }

        else if(bridePanelEnabled)
        {
            titleText.text = "Groom";
            groomPanel.SetActive(true);
            bridePanel.SetActive(false);
            bridePanelEnabled = false;
        }
        yield return new WaitForSeconds(0f);
    }

}
