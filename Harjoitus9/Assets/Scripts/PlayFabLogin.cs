using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
public class PlayFabLogin : MonoBehaviour 
{
    [Header("LOGIN")]
    private string userEmailLogin;
    private string userPasswordLogin;
    public void Start() 
    {
        // Tarkistetaan ettei TitleID ole tyhjä eli null
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            // Lisää oma TitleID,jonka löydät PlayFab pilven Game Managerista
            PlayFabSettings.TitleId = "97906"; 
        }
    }
    // Tämä metodi suoritetaan jos Loggaus onnistuu
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
    }
    // Tämä metodi suoritetaan jos loggaus epäonnistuu
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
    public void GetUserPasswordLogin(string passwordIn)
    {
        userPasswordLogin = passwordIn;
    }
    public void GetUserEmailLogin(string emailIn)
    {
        userEmailLogin = emailIn;
    }
    public void LogIn()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = userEmailLogin
        ,
            Password = userPasswordLogin
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, 
            OnLoginFailure);
    }
}

