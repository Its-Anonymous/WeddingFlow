using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Networking;
//using GamesDepart;
using Facebook.Unity;
using System;
using WedingFlowJsonConverter;


//using PetrushevskiApps.Utilities;

public class ApiController : MonoBehaviour
{
    public Texture2D Player_DummyAvatar;
    public string username;
    public string password;
    public string authorization;

    private void Awake()
    {
            if (StartOnAwake) StartConnectionCheck();
        authorization = authenticate();
    }
    private string authenticate()
    {
        string auth = username + ":" + password;
        auth = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
        auth = "Basic " + auth;
        return auth;
    }




    //--------------------USER LOGIN/REGISTRATION--------------------

    #region USER LOGIN API

    public string apiBaseURL;
    public string UserRegistrationApi;
    public IEnumerator UserLoginReg(string username, string email, string password, string gender, string age,string authProvider,  string platform, string texture,  GameObject loadingScreen)
    {
        authenticate();
        loadingScreen.SetActive(true);
        WWWForm form = new WWWForm();
        form.AddField("userName", username);
        form.AddField("email", email);
        form.AddField("password", password);
        form.AddField("gender", gender);
        form.AddField("age", age);        
        form.AddField("authProvider", authProvider);
        form.AddField("platform", platform);
        form.AddField("image", texture);
        // form.AddField("country", city);

        Debug.Log("--------Send Data------- " + username + " " + email + " " + password + " " +gender + " " + age + " " + platform );

       //Debug.Log("--------Send Data------- " + userName + " " + email + " " + city + "" + platform + " " + authProvider + " " + texture);
        using (var w = UnityWebRequest.Post(apiBaseURL + UserRegistrationApi, form))
        {
            w.chunkedTransfer = false;
            w.SetRequestHeader("AUTHORIZATION", authorization);
            yield return w.SendWebRequest();
            if (w.isNetworkError || w.isHttpError)
            {
                if (w.isNetworkError)
                {
                    Debug.Log("Network Error");
                    ScreenManager.instance.messagePopUpRef.ShowMessagePanelText("Network Error");
                }
                else
                {
                    Debug.Log("Http Error");
                    ScreenManager.instance.messagePopUpRef.ShowMessagePanelText("Http Error");
                }
                Debug.Log("User Login Fail");

                ScreenManager.instance.messagePopUpRef.ShowMessagePanelText("User Login Fail");
                Debug.Log(w.responseCode);
                Debug.Log(w.error);
            }
            else
            {
                //Debug.Log("User Login Successfully");
                Debug.Log("Response: " + w.downloadHandler.text);

                //ScreenManager.instance.messagePopUpRef.ShowMessagePanelText("Display Message else");
                var responseData = LoginRegister.FromJson(w.downloadHandler.text).Data;

                //if (responseData == null)
                //{
                //    loadingScreen.SetActive(false);
                //    ScreenManager.instance.messagePopUpRef.ShowMessagePanelText("No Response From The Server");
                //    yield break;
                //}
                //else
                //{

                //}

                playerProfileDataUpdate(responseData.ApiToken, responseData.AuthProvider, responseData.Platform, responseData.Id, responseData.Username, responseData.Email,
                                        responseData.Image, responseData.Gender, responseData.Age, responseData.Zipcode, responseData.UserAddress, responseData.CityState);

                Debug.Log("PlayerProfile.Player_Access_Token " + PlayerProfile.Player_Access_Token);


                ScreenManager.instance.EnableDisableHomeScreen(true);
            }

            loadingScreen.SetActive(false);

        }
    }

    
    public void PlayerSignInRegistrationApiMethod(string username, string email, string password, string gender,string age, string authProvider, string texture, GameObject loadingScreen)
    {
        Debug.Log("Reached Under PlayerSignInRegistrationApiMethod-----------");
        string platform;
        if (Application.platform == RuntimePlatform.Android)
        {
            platform = "Android";
            Debug.Log(platform);
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            platform = "iOS";
            Debug.Log(platform);
        }
        else
        {
            platform = "Android";
            Debug.Log(platform);
        }

        StartCoroutine(UserLoginReg(username, email, password ,gender, age, authProvider, platform, texture, loadingScreen));
    }

    #endregion

   

    public void playerProfileDataUpdate(string AccessToken, string AuthProvider, string Platform, string UserId, string UserName, string UserEmail, string Image, string Gender, string Age, string ZipCode, string UserAddress, string CityState)
    {
        PlayerProfile.Player_Access_Token = AccessToken;
        PlayerProfile.authProvider = AuthProvider;
        PlayerProfile.Player_Platform = Platform;
        PlayerProfile.Player_rawImage_Texture2D = TextureConverter.Base64ToTexture2D(Image);
        PlayerProfile.Player_UserID = EmailLogin.instance.UserID = UserId;
        PlayerProfile.Player_UserName = UserName;
        PlayerProfile.Player_Email = UserEmail;
        PlayerProfile.Player_Gender = Gender;
        PlayerProfile.Player_Age = Age;
        PlayerProfile.Player_ZipCode = ZipCode;
        PlayerProfile.Player_Address = UserAddress;
        PlayerProfile.Player_CityState = CityState;

        SaveDataInPlayerPrefs();
    }
    
   public void SaveDataInPlayerPrefs()
   {
       PlayerPrefs.SetString(ConstantVariables.AccessToken, PlayerProfile.Player_Access_Token);
       PlayerPrefs.SetString(ConstantVariables.AuthProvider, PlayerProfile.authProvider);
       PlayerPrefs.SetString(ConstantVariables.UserID, PlayerProfile.Player_UserID);
       PlayerPrefs.SetString(ConstantVariables.UserName, PlayerProfile.Player_UserName);
       PlayerPrefs.SetString(ConstantVariables.UserEmail, PlayerProfile.Player_Email);
       PlayerPrefs.SetString(ConstantVariables.UserGender, PlayerProfile.Player_Gender);
       PlayerPrefs.SetString(ConstantVariables.UserAge, PlayerProfile.Player_Age);
       PlayerPrefs.SetString(ConstantVariables.UserZipCode, PlayerProfile.Player_ZipCode);
       PlayerPrefs.SetString(ConstantVariables.UserAddress, PlayerProfile.Player_Address);
       PlayerPrefs.SetString(ConstantVariables.UserCityState, PlayerProfile.Player_CityState);
       PlayerPrefs.SetString(ConstantVariables.UserPicture, TextureConverter.Texture2DToBase64(PlayerProfile.Player_rawImage_Texture2D));
       PlayerPrefs.Save();
   }
   


    #region GetTexture

    public IEnumerator GetTexture(string image)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(image);
        yield return www.SendWebRequest();

        Texture myTexture = DownloadHandlerTexture.GetContent(www);
       //ScreenManager.instance.profileScreenRef.userProfileImage.texture = myTexture;
    }

    #endregion



    //--------------------UPDATE USER PROFILE--------------------

    #region UPDATE USER PROFILE API
    /*
    public string UpdateUserProfileApi;

    public IEnumerator UpdateUserProfileMethod(string userName, string city, string texture, GameObject loadingScreen)
    {
        loadingScreen.SetActive(true);

        WWWForm form = new WWWForm();
        form.AddField("userName", userName);
        form.AddField("country", city);
        form.AddField("image", texture);

        Debug.Log("----------------------" + userName + " " + city + " " + texture + " " + loadingScreen + " " + "   Update User Profile Method Is working perfectly-------------------  ");

        using (var w = UnityWebRequest.Post(apiBaseURL + UpdateUserProfileApi, form))
        {
            w.chunkedTransfer = false;
          //  string accesToken = PlayerProfile.Player_Access_Token;
            w.SetRequestHeader("Authorization", "Bearer " + accesToken);
            yield return w.SendWebRequest();

            if (w.isNetworkError || w.isHttpError)
            {
                if (w.isNetworkError)
                {
                    Debug.Log("Network Error");
                }
                else
                {
                    Debug.Log("Http Error");
                }
                Debug.Log("UpdateUserProfileApi Fail");

                Debug.Log(w.responseCode);
                Debug.Log(w.error);
            }
            else
            {

                Debug.Log(userName + " " + city + " " + texture + " " + loadingScreen + " " + "   Update User Profile Method Is working perfectly-------------------  ");
                Debug.Log("Player Data Updated Successfully");
                Debug.Log("Response: " + w.downloadHandler.text);

                var responseData = UserLogin.FromJson(w.downloadHandler.text).User;

                Updating Player Data in Player Profile Script
                playerProfileDataUpdate(responseData.AccessToken, responseData.AuthProvider, responseData.Platform, responseData.UserId, responseData.UserName, responseData.Email,
                responseData.Country, responseData.Score, responseData.Level, responseData.Image);

                Debug.Log("PlayerProfile.Player_Access_Token " + PlayerProfile.Player_Access_Token);

                ScreenManager.instance.EnableDisableEditProfileScreen(false);
            }
            loadingScreen.SetActive(false);
        }
    }
    */
    #endregion

   

    
    #region FETCHING CARDS API
    /*
    public string fetchCardsAPi;

    public void fetchCards(GameObject loadingScreen)
    {
        StartCoroutine(fetchCardsMethod(loadingScreen));
    }

    public IEnumerator fetchCardsMethod(GameObject loadingScreen)
    {
        GameScreen.choices.Clear();

        loadingScreen.SetActive(true);

        using (var w = UnityWebRequest.Get(apiBaseURL + fetchCardsAPi))
        {
            yield return w.SendWebRequest();

            if (w.isNetworkError || w.isHttpError)
            {


                if (w.isNetworkError)
                {
                    Debug.Log("Network Error");
                }
                else
                {
                    Debug.Log("Http Error");
                }
                Debug.Log("fetchCardsAPi Fail");

                Debug.Log(w.responseCode);
                Debug.Log(w.error);
            }

            else
            {
                Debug.Log("Data Fetced Successfully");
                Debug.Log("Response: " + w.downloadHandler.text);

                var responseData = FetchCards.FromJson(w.downloadHandler.text);

                if (responseData == null)
                {
                    ScreensManager.instance.messagePopUpRef.ShowMessagePanelText("No Response From The Server");
                    ScreensManager.instance.messagePopUpRef.okBtn.onClick.AddListener(() => ScreensManager.instance.messagePopUpRef.DisableScreens());
                    loadingScreen.SetActive(false);
                    yield break;
                }

                Debug.Log("responseData fetchCardsAPi: " + responseData);

                ScreensManager.instance.gameScreenRef.totalCards = responseData.TotalQuestions;

                foreach (var item in responseData.Questions)
                {
                    var QuestionId = item.QuestionId;
                    var Question = item.QuestionQuestion;
                    var choice1 = item.Choice1;
                    var choice2 = item.Choice2;
                    var choice3 = item.Choice3;
                    var row = Tuple.Create(QuestionId, Question, choice1, choice2, choice3);
                    GameScreen.choices.Add(row);
                }
            }
            loadingScreen.SetActive(false);
            Timmer.instance.TimeOn_Off();
        }
    }
    */
#endregion
    
    //--------------------FETCHING CARDS End--------------------




    //--------------------CONNECTIVITY CHECK--------------------
    
    #region CONNECTIVITY CHECK API

    private bool printDebugMessages;
    private bool StartOnAwake = true;


    private bool isConnected;
    private Coroutine connectionTestCoroutine;
    private bool isConnectedDebugToggle = true;
    public bool IsTestingConnectivity { get; private set; } = false;

    public bool IsConnected
    {
        get
        {
            return isConnected;
        }
        private set
        {
            PrintDebugMessage($"Is Connected:: {isConnected}", MessageType.Verbose);
        }
    }


    public void StartConnectionCheck()
    {
        if (connectionTestCoroutine == null)
        {
            connectionTestCoroutine = StartCoroutine(TestConnection());
            IsTestingConnectivity = true;
        }
        else
        {
            PrintDebugMessage("Connection check already started!", MessageType.Warning);
        }
    }

    public IEnumerator TestConnection()
    {
        while (true)
        {
            if (!string.IsNullOrEmpty("https://www.google.com/"))
            {
                UnityWebRequest webRequest = new UnityWebRequest("https://www.google.com/");
                yield return webRequest.SendWebRequest();

                if (webRequest.result == UnityWebRequest.Result.Success)
                {
                    if (Application.isEditor)
                    {
                        IsConnected = true;
                        ScreenManager.instance.networkErroPopUpRef.SetActive(false);
     //                   Debug.Log(isConnected+" -----True----------If");
                        if (PlayerPrefs.HasKey(ConstantVariables.AuthProvider) && PlayerPrefs.GetString("loggedIn") == "false")
                        {
                    //        ScreenManager.instance.loginStateCheckRef.ByPassLogin();
                        }
                    }
                    else
                    {

                        IsConnected = true;
                        ScreenManager.instance.networkErroPopUpRef.SetActive(false);
                        Debug.Log(isConnected+"------------else");
                        if (PlayerPrefs.HasKey(ConstantVariables.AuthProvider) && PlayerPrefs.GetString("loggedIn") == "false")
                        {
                     //       ScreenManager.instance.loginStateCheckRef.ByPassLogin();
                        }
                    }
                }
                else if (webRequest.result != UnityWebRequest.Result.InProgress)
                {
                    Debug.Log(isConnected + "-----Not Connected");
                    IsConnected = false;
                    ScreenManager.instance.networkErroPopUpRef.SetActive(true);
                    PlayerPrefs.SetString("loggedIn", "false");
                    PrintDebugMessage($"Connection Error::{webRequest.error}", MessageType.Warning);

                }
            }

            else
            {

                Debug.Log(isConnected + "-----Not Connected");
                IsConnected = false;
                ScreenManager.instance.networkErroPopUpRef.SetActive(true);
                PlayerPrefs.SetString("loggedIn", "false");
                PrintDebugMessage($"Ping URL in Connectivity Manager ( Inspector ) is missing", MessageType.Error);
            }
            yield return new WaitForSeconds(2F);
        }
    }

    private void PrintDebugMessage(string msg, MessageType msgType)
    {
        if (printDebugMessages)
        {
            switch (msgType)
            {
                case MessageType.Warning:
                    Debug.LogWarning($"ConnectivityManager:: {msg}");
                    break;
                case MessageType.Error:
                    Debug.LogError($"ConnectivityManager:: {msg}");
                    break;
                default:
                    Debug.Log($"ConnectivityManager:: {msg}");
                    break;
            }

        }
    }

    private enum MessageType
    {
        Verbose,
        Warning,
        Error
    }


    #endregion
    
}


