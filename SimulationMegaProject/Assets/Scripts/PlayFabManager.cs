using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
//using Newtonsoft.Json;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayFabManager : MonoBehaviour
{

    [Header("UI")]
    public TextMeshProUGUI messageText;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;



    public void RegisterButton()
    {
        if (passwordInput.text.Length<6)
        {
            messageText.text = "Password too short";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }


    public void Loginbutton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
        
    }

    

    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "717C5"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }


    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and logged in!";
    }


    void OnError(PlayFabError error)
    {
        messageText.text = "Wrong E-mail and/or Password";
        //messageText.text = error.ErrorMessage;// gia oles tis periptwseis
        Debug.Log(error.GenerateErrorReport());
    }

    void OnLoginSuccess(LoginResult result)
    {
        messageText.text = "Logged in!";
        SceneManager.LoadSceneAsync("MenuSelection");
        ////tha valw na loadarei to menuScreen kai to check an exei ksanaginei
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password reset mail sent!";
    }

    /* void Start()
     {
         LogIn();
     }


     public void LogIn()
     {
         var request = new LoginWithCustomIDRequest
         {
             CustomId = SystemInfo.deviceUniqueIdentifier,
             CreateAccount = true
         };
         PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
     }

     void OnSuccess(LoginResult result)
     {
         Debug.Log("successful login/account create!");
     }

     */
}
