using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Linq;
public class EmailLogin : MonoBehaviour
{
    public static EmailLogin instance;

    [Space]
    //  public PlayerProfile profile;

    [Space]
    //public Button guestLoginBtn;

    public Button emailLoginBtn;
    public Button SignUpBtn;


    [Space]
    [Header("Home Screen")]
    public HomeScreen Home_Screen;

    [Space]
    [Header("Guest Profile Details")]


    public InputField InputUserName;
    public InputField InputPassword;
    public InputField InputEmail;


    public InputField InputSignUpPassword;
    public InputField InputSignUpEmail;
    // public InputField InputGendre;
    public InputField InputAge;
    public string GendreStringTxt;

    string UserURL1 = "http://localhost/login.php";


    public string UserID;
    public string UserName;
    public string Email;
    public string Password;
    public string Gender;
    public string Age;
    public string AuthProvider;
    public string Platform;

    public Texture2D GuestUserPic;
    public GameObject loadingScreen;

    public ToggleGroup toggleGroup;
    Toggle toggle;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //guestLoginBtn.onClick.AddListener(() => CreateGuestProfile());
        emailLoginBtn.onClick.AddListener(() => SignIn());
        SignUpBtn.onClick.AddListener(() => SignUp());

    }


    //public void Email_Button_Click()
    //{
    //    StartCoroutine(LoginData(inputUsername1, inputPassword1));

    //}
    //IEnumerator LoginData(InputField inputUsername1, InputField inputPassword1)
    //{
    //    WWWForm form = new WWWForm();
    //    form.AddField("username", inputUsername1.text);
    //    form.AddField("password", inputPassword1.text);

    //    WWW www = new WWW(UserURL1, form);
    //    yield return www;

    //    if (www.text[0] == '0')
    //    {
    //        Debug.Log("User Login Success.");
    //    }
    //    else
    //    {
    //        Debug.Log("User Login Failed.");
    //    }
    //}


    public void SignIn()
    {
        Debug.Log("Login submit Working");
        Email = InputEmail.text;
        Password = InputPassword.text;
        //string base64 = TextureConverter.Texture2DToBase64(GuestUserPic);
        Debug.Log("rLogin submit Working Perfectly---------------------");
        Debug.Log(Email + " " + Password + " " + loadingScreen );
        ScreenManager.instance.apiControllerRef.PlayerSignInRegistrationApiMethod(UserName, Email, Password, Gender, Age, AuthProvider, "" , loadingScreen);
        // ScreenManager.instance.apiControllerRef.PlayerRegistrationApiMethod(GuestUserName, GuestUserEmail, "New York", ConstantVariables.Guest, base64, loadingScreen);
        
    }
    public void SignUp()
    {
        Debug.Log("SignUp submit Working");
        UserName = InputUserName.text;
        Email = InputSignUpEmail.text;
        Password = InputSignUpPassword.text;
        toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        Debug.Log(toggle.name + "--" + toggle.GetComponentInChildren<Text>().text);
        Gender = toggle.GetComponentInChildren<Text>().text;
        Age = InputAge.text;
        string base64 = TextureConverter.Texture2DToBase64(GuestUserPic);
        Debug.Log("rLogin submit Working Perfectly---------------------");

       // string base64 ="";
        Debug.Log(UserName+ " " + Email + " " + Password + " " + loadingScreen + " " + Gender + " " + Age);
        //ScreenManager.instance.apiControllerRef.PlayerSignInRegistrationApiMethod(UserName, Email, Password, Gender, ConstantVariables.EmailLogin, Age, base64, loadingScreen);
        //var userImage = dummyImage;

        ScreenManager.instance.apiControllerRef.PlayerSignInRegistrationApiMethod(UserName, Email, Password, Gender,  Age, ConstantVariables.CustomLogin, base64, loadingScreen); //userImage
        // ScreenManager.instance.apiControllerRef.PlayerRegistrationApiMethod(GuestUserName, GuestUserEmail, "New York", ConstantVariables.Guest, base64, loadingScreen);
       
    }
    public string Get_Base64Image()
    {
        string base64String = PlayerPrefs.GetString("Picture");
        return base64String;
    }

}
