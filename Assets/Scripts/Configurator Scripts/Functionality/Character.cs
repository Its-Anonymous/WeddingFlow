using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject UIPanel;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if(!UIManager.instance.ShopPanel.activeSelf)
        {
            UIManager.instance.CharacterBtnClick(UIPanel, spriteRenderer);
        }
}
}
