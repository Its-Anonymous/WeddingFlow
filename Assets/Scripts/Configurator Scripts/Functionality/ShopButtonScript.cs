using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopButtonScript : MonoBehaviour //, IBeginDragHandler,IDragHandler
{
    public GameObject prefab;

    private void Start()
    {
        Button butt = this.GetComponent<Button>();
        butt.onClick.AddListener(() => createObject());
    }

    // commented by ali since its causing issue with UI
    //    public void OnBeginDrag(PointerEventData eventData)
    //    {
    //        Debug.Log(eventData.position);
    //        Vector3 pos = Camera.main.ScreenToWorldPoint(eventData.position);
    //        GameManager.instance.selectedObject = Instantiate(prefab,new Vector3(pos.x, pos.y,0), Quaternion.identity).GetComponent<Transform>();
    //        //GameManager.instance.selectedObject.parent = transform.parent.transform.parent;
    //        // GameManager.instance.selectedObject.localScale = new Vector3(1, 1, 1);
    //        UIManager.instance.ShopPanel.SetActive(false);
    //    }

    //    public void OnDrag(PointerEventData eventData)
    //    {
    //       // Debug.Log("Begin");
    //    }
    //    /*
    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //   Debug.LogError("In");
    //   RaycastHit hit;
    //   Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //   if (Physics.Raycast(ray, out hit))
    //   {
    //       Instantiate(prefab, hit.point, Quaternion.identity);
    //     //  selectedObject.position = new Vector3(hit.point.x, selectedObject.position.y, hit.point.z); ;
    //   }
    //}*/


    public void createObject()
    {
        Instantiate(prefab, GameManager.instance.itemSpawner.position, Quaternion.identity,GameManager.instance.itemSpawner);
        UIManager.instance.ShopPanel.SetActive(false);
    }
}
