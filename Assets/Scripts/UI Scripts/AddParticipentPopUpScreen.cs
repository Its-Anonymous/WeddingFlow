using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AddParticipentPopUpScreen : MonoBehaviour
{
    public static AddParticipentPopUpScreen instance;

    public Button closeBtn;
    public InputField fullNameTxt;
    public Dropdown genderTxt;
    public Dropdown ROCTxt;
    public Button addParticipantBtn;

    public ParticipantInfoPrefab participantInfoPrefab;
    public GameObject participantScollViewContent;
    public static Dictionary<int, Tuple<string, string, string>> dict = new Dictionary<int, Tuple<string, string, string>>();


    public bool isClicked = false;
    public GameObject fadeScreeen;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        closeBtn.onClick.AddListener(() => EnableDisableAddParticipentPopUp(false));
        //addParticipantBtn.onClick.AddListener(() => AddPrefabRow());
    }

    //public void AddParticipentPopUp()
    //{
    //    if (!isClicked)
    //    {
    //        Debug.Log(isClicked);
    //        isClicked = true;
    //        fadeScreeen.SetActive(true);
    //        EnableDisableAddParticipentPopUp(true);
    //    }
    //    else if (isClicked)
    //    {
    //        Debug.Log(isClicked);
    //        isClicked = false;
    //        fadeScreeen.SetActive(false);
    //        EnableDisableAddParticipentPopUp(false);
    //    }
    //}
 
    public void ProceedToSlots()
    {
        int i = 0;
        foreach (var item in participantScollViewContent.gameObject.GetComponentsInChildren<ParticipantInfoPrefab>())
        {
            string name = item.userNameTxt.text;
            string gender = item.userGenderTxt.text;
            string relation = item.relationTxt.text;
            var val = Tuple.Create(name, gender, relation);
            dict.Add(i, val);
            i++;
        }
        Debug.Log("Dick Filled"+ dict);
    }

    public void AddPrefabRow()
    {
        ProceedToSlots();
        //Debug.Log(fullNameTxt.text);

        var betObj = Instantiate(participantInfoPrefab, participantScollViewContent.transform);
        foreach (var item in dict)
        {
            betObj.SetDetails(item.Value.Item1,item.Value.Item2,item.Value.Item3);
        }
    }

    public void DestroyPrefabs()
    {
        foreach (var child in participantScollViewContent.transform.GetComponentsInChildren<ParticipantInfoPrefab>())
        {
            Destroy(child.gameObject);
        }
        dict.Clear();
    }

    public void EnableDisableAddParticipentPopUp(bool status)
    {
        DestroyPrefabs();
        this.gameObject.SetActive(status);
    }

    void Update()
    {
        
    }
}
