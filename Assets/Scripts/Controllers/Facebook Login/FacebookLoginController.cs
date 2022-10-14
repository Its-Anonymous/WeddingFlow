using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using DG.Tweening;
using System;

public class FacebookLoginController : MonoBehaviour
{

    [Space]
  //  public PlayerProfile profile;

    [Header("FacebookScreen UI Elements")]
    public Button FBLoginBtn;

    [Space]
    [Header("Home Screen")]
    public HomeScreen homeScreen;

    [Space]
    [Header("Login Screen")]
    public LoginScreen loginScreen;

    public static AccessToken accessToken;

    public GameObject loadingScreen;
    private void Awake()
    {

        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                {
                    FB.ActivateApp();
                    Debug.Log("Activating app fb init if");
                }

                else
                    Debug.LogError("Couldn't initialize app");
                if (FB.IsLoggedIn)
                {
                    Debug.Log("Successfull Login Awake");
                    AfterSuccessfullLogin();
                }
            },
            isGameShown =>
            {
                if (!isGameShown)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;

            });
        }
        else
        {
            FB.ActivateApp();
            Debug.Log("else Facebook Login");
            AfterSuccessfullLogin();
        }

     //   profile = FindObjectOfType<PlayerProfile>();
    }

    private void Start()
    {
        FBLoginBtn.onClick.AddListener(() => FacebookLogin());
        //if (!FB.IsLoggedIn)
        //{
        //    StartCoroutine(EnableDisableLoginScreen());
        //} 
    }

    private IEnumerator EnableDisableLoginScreen()
    {
        yield return new WaitForSeconds(0.5f);
        ScreenManager.instance.EnableDisableLoginScreen(true);
    }



    #region Login/Logout

    public void FacebookLogin()
    {

        FBLoginBtn.transform.DOPunchScale(new Vector3(0.1f, 0.1f), 0.3f).OnComplete(() =>
        {
            Debug.Log("Facebook Login working");
            var permission = new List<string>() { "email", "public_profile" };
            FB.LogInWithReadPermissions(permission, AuthCallback);
            Debug.Log(permission);
        });
    }

    public static void FacebookLogOut()
    {
        Debug.Log("FacebookLogOut");
        FB.LogOut();
    }

    private void AuthCallback(ILoginResult loginResult)
    {
        if (FB.IsLoggedIn)
        {
            AfterSuccessfullLogin();
        }
        else
        {
            Debug.Log("Login Failed");
        }
    }

    #endregion 


    #region if Fb is Logged in Anywhere/Any app

    public void AfterSuccessfullLogin()
    {
        // generate token and facebook id
        if (FB.IsLoggedIn)
        {
           // PlayerProfile.isAlreadyReadyLoggedIn = true;
            Debug.Log("Successful Login After ");
            accessToken = AccessToken.CurrentAccessToken;
            Debug.Log("Login sucess AccessToken.CurrentAccessToken  " + AccessToken.CurrentAccessToken);
            StartCoroutine(UpdateData());
        }
        else
        {
            EnableDisableLoginScreen();
        }
    }


    /// <summary>
    /// Hits 2 different APIs
    /// one for profile picture
    /// one for name id email
    /// </summary>
    /// <returns></returns>

    IEnumerator UpdateData()
    {
        if (FB.IsLoggedIn)
        {
            ScreenManager.instance.EnableDisableHomeScreen(true);
            FB.API("/me?fields=id,name,email", HttpMethod.GET, GetData);
          //  FB.API("me/picture?type=square&height=350&width=350", HttpMethod.GET, GetPicture);
            Debug.Log("Facebook UpdateData");

            yield return null;
        }
        else
            Debug.Log("Failed to Get Data");
    }


    /// <summary>
    /// gets API response for name email and userid
    /// </summary>
    /// <param name="result"></param>
    
    private void GetData(IGraphResult result)
    {
        if (result.Error != null)
        {
            Debug.Log(result.Error);
            return;
        }

        string Player_UserName;
        string Player_Email;
        string Player_City ;
        Debug.Log(result);

        //if (result.ResultDictionary.TryGetValue("id", out Plar_UserID))
        //{
        //    PlayerProfile.Player_UserID = Player_UserID;
        //    Debug.Log(Player_UserID);
        //}
        if (result.ResultDictionary.TryGetValue("name", out Player_UserName))
        {
            //PlayerProfile.Player_UserName = Player_UserName;
            Debug.Log(Player_UserName);
        }

        if (result.ResultDictionary.TryGetValue("email", out Player_Email))
        {
           // PlayerProfile.Player_Email = Player_Email;
            Debug.Log(Player_Email);
        }
       
    }



    /// <summary>
    /// gets API response for profile picture
    ///  without downloading
    /// </summary>
    /// <param name="result"></param>
    /*
    public void GetPicture(IGraphResult result)
    {
        Debug.Log(result);
        if (result.Error == null && result.Texture != null)
        {
            PlayerProfile.Player_rawImage_Texture2D = result.Texture;
        }
        else
        {
            Debug.Log(result.Error);
        }
        PlayerPrefs.SetString(ConstantVariables.AuthProvider, ConstantVariables.Facebook);
        PlayerPrefs.Save();
        Debug.Log("AuthProvider " + PlayerPrefs.GetString(ConstantVariables.AuthProvider));
        ChangeScreen();
    }

    private void ChangeScreen()
    {
        ScreensManager.instance.apiControllerRef.PlayerRegistrationApiMethod(PlayerProfile.Player_UserName, PlayerProfile.Player_Email, "NEw York", ConstantVariables.Facebook, TextureConverter.Texture2DToBase64(PlayerProfile.Player_rawImage_Texture2D), loadingScreen);

    }

    */
    #endregion


   
}
