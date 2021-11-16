using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
   public Text usernameText;
   public Button loginButton;

   private AuthStore authStore = AuthStore.Instance;

   public void Start()
   {
      loginButton.onClick.AddListener(onLoginClick);
      authStore.OnAuthenticateSuccess += OnAuthenticateSuccess;
      authStore.OnAuthenticateStart += OnAuthenticateStart;
      authStore.OnAuthenticateFail += OnAuthenticateFail;
   }

   public void onLoginClick()
   {
      var credentials = new Credentials();
      credentials.username = "Test";
      
      authStore.login(credentials);
   }

   void OnAuthenticateSuccess()
   {
      SceneManager.LoadScene ("MainMenuScene");
   }
   
   void OnAuthenticateStart()
   {
      loginButton.interactable = false;
   }
   
   void OnAuthenticateFail()
   {
      loginButton.interactable = true;
   }

   public void OnDestroy()
   {
      loginButton.onClick.RemoveAllListeners();
   }
   
}
