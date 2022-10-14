using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DesignScreen : MonoBehaviour
{
    void Start()
    {

    }
    public void backtoHomefromDesign()
    {
        ScreenManager.instance.homeScreenRef.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    void Update()
    {
        
    }
}
