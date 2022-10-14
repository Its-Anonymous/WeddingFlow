using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using DG.Tweening;

public class ItemPanel : MonoBehaviour
{
    public GameObject itemMenu;
    public GameObject guestPanel;
    public GameObject chairPanel;
    public GameObject tablePanel;
    public GameObject decorPanel;
    public GameObject objectScalingPanel;

    public float defPos;
    public float offset;

    private void OnEnable()
    {
        this.transform.DOLocalMoveX(offset, 0.5f);
        if(objectScalingPanel.GetComponent<objectScalingPanel>().objectToScale != null)
        {
            objectScalingPanel.GetComponent<objectScalingPanel>().objectToScale.GetComponent<ItemScript>().disableObject();
        }
        UIManager.instance.BridePanel.SetActive(false);
        UIManager.instance.GroomPanel.SetActive(false);
        UIManager.instance.BGPanel.SetActive(false);
        UIManager.instance.zoomOut();
    }

    private void Start()
    {
        guestPanel.SetActive(true);
        chairPanel.SetActive(false);
        tablePanel.SetActive(false);
        decorPanel.SetActive(false);
    }

    public void guestPanelButton()
    {
        guestPanel.SetActive(true);
        chairPanel.SetActive(false);
        tablePanel.SetActive(false);
        decorPanel.SetActive(false);
    }

    public void chairPanelButton()
    {
        guestPanel.SetActive(false);
        chairPanel.SetActive(true);
        tablePanel.SetActive(false);
        decorPanel.SetActive(false);
    }

    public void tablePanelButton()
    {
        guestPanel.SetActive(false);
        chairPanel.SetActive(false);
        tablePanel.SetActive(true);
        decorPanel.SetActive(false);
    }

    public void decorPanelButton()
    {
        guestPanel.SetActive(false);
        chairPanel.SetActive(false);
        tablePanel.SetActive(false);
        decorPanel.SetActive(true);
    }
    public void closePanelButton()
    {
        this.transform.DOLocalMoveX(defPos, 0.5f);
        Invoke("closePanel", 0.1f);
    }
    void closePanel()
    {
        this.gameObject.SetActive(false);
    }
}
