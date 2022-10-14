using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;


public class ItemScript : MonoBehaviour
{
    public string itemName;
    private Vector3 mOffset;
    private float mZCoord;
    float _spawnDistance = 30f;
    float _terrainYOffset = 300f;
    bool isDrage = false;
    [HideInInspector] public bool isEditingScale;

    public bool objectEnabled;
    bool isAnimating;

    public void OnEnable()
    {
        isDrage = true;
        Physics.queriesHitTriggers = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("debug 1");
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (objectEnabled)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject != this.gameObject)
                    {
                        disableObject();
                    }
                }
            }
        }
        if (objectEnabled)
        {
            if (!isDrage)
                return;
            if (Input.touchCount == 0)
            {
                isDrage = false;
            }
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void OnMouseDown()
    {
        if(!UIManager.instance.ShopPanel.activeSelf)
        { 
        isDrage = true;
        objectEnabled = true;
        UIManager.instance.objectScalePanel.gameObject.SetActive(true);
        UIManager.instance.objectScalePanel.GetComponent<objectScalingPanel>().objectToScale = this.gameObject;
        //UIManager.instance.objectScalePanel.GetComponent<objectScalingPanel>().scale.value = this.transform.localScale.magnitude
        //
        }
    }

    public void OnMouseUp()
    {
        isDrage = false;
        isEditingScale = false;
    }

      
    public void disableObject()
    {
        objectEnabled = false;
        UIManager.instance.objectScalePanel.gameObject.SetActive(false);
        UIManager.instance.objectScalePanel.GetComponent<objectScalingPanel>().objectToScale = null;
    }

}
