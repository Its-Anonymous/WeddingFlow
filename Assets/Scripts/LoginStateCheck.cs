using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginStateCheck : MonoBehaviour
{
    public GameObject loadingScreen;

    void Start()
    {
        if (PlayerPrefs.HasKey(ConstantVariables.AuthProvider))
        {
            Debug.Log("Has Key ConstantVariables.AuthProvider = " + PlayerPrefs.GetString(ConstantVariables.AuthProvider));
            Debug.Log("Has Key : AuthProvider");
            //waitingTime = 0.01f; // 10 sec
            ByPassLogin();
        }
    }

    public void ByPassLogin()
    {
        PlayerPrefs.SetString("loggedIn", "true");
        Debug.Log("Retrieving Data");
        var UserName = PlayerPrefs.GetString("UserName");
        var UserEmail = PlayerPrefs.GetString("UserEmail");        
        var Password = PlayerPrefs.GetString("Password");
        var Gender = PlayerPrefs.GetString("Gender");
        var Age = PlayerPrefs.GetString("Age");
       // var Country = PlayerPrefs.GetString("Country");
        var AuthProvider = PlayerPrefs.GetString(ConstantVariables.AuthProvider);
        string base64String = PlayerPrefs.GetString("Picture");

        ScreenManager.instance.apiControllerRef.PlayerSignInRegistrationApiMethod(UserName, UserEmail, Password, Gender, Age, base64String, AuthProvider, loadingScreen);
    }
}
