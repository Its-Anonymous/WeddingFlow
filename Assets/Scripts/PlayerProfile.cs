using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfile : MonoBehaviour
{
    public static PlayerProfile instance;
    public static Texture2D Player_rawImage_Texture2D;
    public static string Player_Access_Token = "";
    //public static string firebase_token = "";
    public static string Player_UserName = "";
    public static string Player_UserID = "";
    public static string Player_Email = "";
    public static string Player_Gender = "";
    public static string Player_Age = "";
    public static string Player_ZipCode = "";
    public static string Player_Address = "";
    public static string Player_CityState = "";
    public static string Player_Platform = "";
    public static string Player_Score = "";
    public static string Player_Level = "";
    public static string authProvider = "";
    public static bool isNewUser = false;
    public static bool hasSignedIn = false;
    public static bool isAlreadyReadyLoggedIn = false;

    //public static List<string> PlayerPurchasedProductsIDs = new List<string>();
    //public static Dictionary<string  /*productID*/, string /*Count*/> Dict_PlayerPurchasedProductsIDs_And_Count = new Dictionary<string, string>();

    private void Awake()
    {
        instance = this;
    }

    //Start is called before the first frame update
    //void Start()
    //{
        //if (single && single != this.gameObject)
        //{
        //    /// If a singleton already exists, destroy the old one - TODO: Not sure about this behaviour yet. Allows for settings changes with scene changes.
        //    Destroy(single);
        //}

        //single = this.gameObject;
        //DontDestroyOnLoad(this.gameObject);
    //}

    // Update is called once per frame
    //void Update()
    //{

    //}

    //public void ProfileScreenSetter()
    //{
    //    userFullName.text = CustomLoginController.instance.userName_IF.text;
    //    userNickName.text = CustomLoginController.instance.userName_IF.text;
    //    Email.text = CustomLoginController.instance.userEmail_IF.text;
    //    profilePicture.texture = CustomLoginController.instance.imageTexture.mainTexture;
    //}



    public void showPlayerDetails()
    {
        Debug.Log("Player Image"+Player_rawImage_Texture2D);
        //Debug.Log("Player_Fullname"+Player_FullName);
        Debug.Log("Player_Access_Token"+Player_Access_Token);
        Debug.Log("Player_UserName"+Player_UserName);
        Debug.Log("Player_UserID"+Player_UserID);
        Debug.Log("Player_Email"+Player_Email);
        Debug.Log("Player_authProvider"+authProvider);
        Debug.Log("Player OperatingSystem"+Player_Platform);
        Debug.Log("Player_Coins" + Player_Score);
    }


    internal static void clearData()
    {
        Player_rawImage_Texture2D = null;
        //Player_FullName = "";
        Player_Access_Token = "";
        //firebase_token = "";
        Player_UserName = "";
        Player_UserID = "";
        Player_Email = "";
        Player_CityState = "";
        Player_Platform = "";
        Player_Score = "";
        Player_Level = "";
        authProvider = "";
        isNewUser = false;
}
}
