using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticipantInfoPrefab : MonoBehaviour
{
    public Text userNameTxt;
    public Text userGenderTxt;
    public Text relationTxt;
    public Image userImage;
    public Button removeBtn;
    public GameObject participantInfoPrefab;

    void Start()
    {
        removeBtn.onClick.AddListener(() => RemovePrefabRow());
    }

    public void SetDetails(string name, string gender, string relation)
    {
        userNameTxt.text = name;
        userGenderTxt.text = gender;
        relationTxt.text = relation;
        //userImage = image;
    }

    private void RemovePrefabRow()
    {
        Destroy(participantInfoPrefab);
    }

    void Update()
    {

    }
}
