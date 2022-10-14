using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    [Space]
    [Header("Screen Refrences")]
    
    public static ScreenManager instance;


    public ApiController apiControllerRef;

    public GameObject loadingScreen;
    public HomeScreen homeScreenRef;
    public LoginScreen loginScreenRef;
    public SplashScreen splashScreenRef;
    public SignUpScreen signUpScreenRef;
    public DesignScreen designScreenRef;
    public PreviewScreen previewScreenRef;
    public CanvasGroup fadesScreenPanelRef;
    public PreLoginScreen preLoginScreenRef;
    public SettingsScreen settingsScreenRef;
    public DesigningScreen designingScreenRef;
    public SidePanelScreen sidePanelScreenRef;
    public MyDesignsScreen myDesignsScreenRef;
    public FavoritesScreen favoritesScreenRef;
    public EditProfileScreen editProfileScreenRef;
    public NotificationScreen notificationScreenRef;
    public VerificationScreen verificationScreenRef;
    public ResetPasswordScreen resetPasswordScreenRef;
    public PrivacyPolicyScreen privacyPolicyScreenRef;
    public CreateProfileScreen createProfileScreenRef;
    public ForgotPasswordScreen forgotPasswordScreenRef;
    public PaymentSettingsScreen paymentSettingsScreenRef;
    public TermsAndConditionsScreen termsAndConditionsScreenRef;
    public SelectBGAndParticipantsScreen selectBGAndParticipantsScreenRef;

    public GameObject networkErroPopUpRef;
    public MessagePopUp messagePopUpRef;
    public LoginStateCheck loginStateCheckRef;

    private void Awake()
    {
        instance = this;
    }

    public void FadeScreenPanel()
    {
        if (fadesScreenPanelRef.gameObject.activeSelf)
        {
            this.fadesScreenPanelRef.gameObject.SetActive(false);
        }
        else
        {
            this.fadesScreenPanelRef.gameObject.SetActive(true);
            fadesScreenPanelRef.DOFade(0f, 0.5f).OnComplete(() =>
            {
                this.fadesScreenPanelRef.gameObject.SetActive(false);
                this.fadesScreenPanelRef.GetComponent<CanvasGroup>().alpha = 1;
            });
        }
    }


    public void EnableDisablePreLoginScreen(bool status)
    {
        preLoginScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisableLoginScreen(bool status)
    {
        loginScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisableSignUpScreen(bool status)
    {
        signUpScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisableVerificationScreen(bool status)
    {
        verificationScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisableCreateProfileScreen(bool status)
    {
        createProfileScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisableForgotPasswordScreen(bool status)
    {
        forgotPasswordScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisableResetPasswordScreen(bool status)
    {
        resetPasswordScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisableSidePanelScreen(bool status)
    {
        sidePanelScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisableHomeScreen(bool status)
    {
        homeScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisableDesignScreen(bool status)
    {
        designScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisableSelectBGAndParticipantsScreen(bool status)
    {
        selectBGAndParticipantsScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisableDesigningScreen(bool status)
    {
        designingScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisablePreviewScreen(bool status)
    {
        previewScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisableNotificationScreen(bool status)
    {
        notificationScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisableMyDesignsScreen(bool status)
    {
        myDesignsScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisableFavoritesScreen(bool status)
    {
        favoritesScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisableEditProfileScreen(bool status)
    {
        editProfileScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisableSettingsScreen(bool status)
    {
        settingsScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisablePaymentSettingsScreen(bool status)
    {
        paymentSettingsScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisablePrivacyPolicyScreen(bool status)
    {
        privacyPolicyScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisableTermsAndConditionsScreen(bool status)
    {
        termsAndConditionsScreenRef.gameObject.SetActive(status);
    }

    public void EnableDisableSplashScreen(bool status)
    {
        splashScreenRef.gameObject.SetActive(status);
    }

 
    }

