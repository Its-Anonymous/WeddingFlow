using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectScalingPanel : MonoBehaviour
{
    public GameObject objectToScale;
    public Slider scale;

    private void Update()
    {
        scale.onValueChanged.AddListener(delegate { changeObjectScale(); });
    }

    void changeObjectScale()
    {
        if (objectToScale != null)
        {
            objectToScale.transform.localScale = new Vector2(scale.value, scale.value);
        }
    }

    public void stopEditing()
    {
        objectToScale.GetComponent<ItemScript>().disableObject();
    }

    public void deleteObject()
    {
        Destroy(objectToScale);
        objectToScale = null;
        this.gameObject.SetActive(false);
    }
}
