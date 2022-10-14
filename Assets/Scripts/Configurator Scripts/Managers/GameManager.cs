using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject CameraMain;
    public Transform itemSpawner;
    public Transform selectedObject;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }
    public Vector3 currentPos;
    public Vector3 previousPos;
    Vector3 pos;
    public float perspectiveZoomSpeed = 0.5f;
    // Update is called once per frame
    void Update()
    {

    }

    public bool IsPointerOverUIObject1()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.GetTouch(0).deltaPosition.x, Input.GetTouch(0).deltaPosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    public bool IsPointerOverUIObject2()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.GetTouch(1).deltaPosition.x, Input.GetTouch(1).deltaPosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
