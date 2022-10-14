using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("Panels")]
    public GameObject BGPanel;
    public GameObject ShopPanel;
    public GameObject GroomPanel;
    public GameObject BridePanel;
    public GameObject ShopPanelActive;
    public GameObject SelectedItemPanel;
    public GameObject objectScalePanel;
    [Header("Canvas UI")]
    public Button BGButton;
    public SpriteRenderer Background;
    public SpriteRenderer currentCharacter;
    public List<Sprite> GroomSprites = new List<Sprite>();
    public List<Sprite> BrideSprites = new List<Sprite>();
    public List<Sprite> BackgroundSprites = new List<Sprite>();
    [Header("Misc")]

    bool isTop = true;


    void Start()
    {
        instance = this;
    }

    public void OnBGButtonClick()
    {
        if (!UIManager.instance.ShopPanel.activeSelf)
        {

            if (BGPanel.active)
            {
                DisableAllPanels();
            }
            else
            {
                DisableAllPanels();
                BGPanel.SetActive(true);
            }
        }
    }
    public void ChangeMoge(int index)
    {
        Background.sprite = BackgroundSprites[index];

    }
    public void ChangeCharacter(int index)
    {
        currentCharacter.sprite = GroomSprites[index];

    }

    public void CharacterBtnClick(GameObject Panel,SpriteRenderer spriteRenderer)
    {
        currentCharacter = spriteRenderer;
        if (Panel.active)
        {
            //BGButton.interactable = true;
            DisableAllPanels();
            LeanTween.move(Camera.main.gameObject, new Vector3(0,0, -10), 0.2f);
            LeanTween.value(Camera.main.gameObject, Camera.main.orthographicSize, 5, 0.2f).setOnUpdate((float val) => { Camera.main.orthographicSize = val; });
        }
        else
        {
            //BGButton.interactable = false;
            LeanTween.move(Camera.main.gameObject, new Vector3(currentCharacter.gameObject.transform.position.x, currentCharacter.gameObject.transform.position.y, -10), 0.2f);
            LeanTween.value(Camera.main.gameObject, Camera.main.orthographicSize, 2, 0.2f).setOnUpdate((float val) => { Camera.main.orthographicSize = val; });
            DisableAllPanels();
            Panel.SetActive(true);
        }
    }

    public void zoomOut()
    {
        LeanTween.move(Camera.main.gameObject, new Vector3(0, 0, -10), 0.2f);
        LeanTween.value(Camera.main.gameObject, Camera.main.orthographicSize, 5, 0.2f).setOnUpdate((float val) => { Camera.main.orthographicSize = val; });
    }


    public void OnShopButtonClick()
    {
        ShopPanel.SetActive(true);
    }
  

    public void DisableAllPanels()
    {
        BridePanel.SetActive(false);
        GroomPanel.SetActive(false);
        BGPanel.SetActive(false);
        ShopPanelActive.SetActive(false);
        ShopPanel.SetActive(false);
    }


    public void ItemSelected()
    {
        SelectedItemPanel.SetActive(true);
    }
    public void ItemDiSelected()
    {
        SelectedItemPanel.SetActive(false);
        if (GameManager.instance.selectedObject != null)
        {
            GameManager.instance.selectedObject.GetComponent<BoxCollider>().enabled = true;
            GameManager.instance.selectedObject = null;
            ShopPanel.SetActive(true);
        }
    }


 

    public void DeleteBtnClicked()
    {
        if (GameManager.instance.selectedObject != null)
        {
            Destroy(GameManager.instance.selectedObject.gameObject);
            ItemDiSelected();
            GameManager.instance.selectedObject = null;
        }
    }
    public bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
