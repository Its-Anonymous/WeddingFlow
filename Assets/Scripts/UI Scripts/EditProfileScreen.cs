using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EditProfileScreen : MonoBehaviour
{
    public Button backBtn;
    public Button uploadProfilePicBtn;
    public Text userNameTxt;
    public Text userAddressTxt;
    public Text userCityOrStateTxt;
    public Text userZipCodeTxt;
    public Button updateProfileBtn;

    void Start()
    {
        backBtn.onClick.AddListener(() => BackBtnClick());
        updateProfileBtn.onClick.AddListener(() => UpdateProfileBtnClick());
    }

    private void OnEnable()
    {
        //ScreenManager.instance.FadeScreenPanel();
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void BackBtnClick()
    {
        ScreenManager.instance.EnableDisableEditProfileScreen(false);
    }

    public void UpdateProfileBtnClick()
    {
        ScreenManager.instance.EnableDisableEditProfileScreen(false);
    }

    void Update()
    {

    }
}
