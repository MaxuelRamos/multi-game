using System;
using System.Net.Http;
using Stores;
using UnityEngine;

public class AuthStore : Singleton<AuthStore>
{
    private static readonly string PATH = AppStore.Instance.ServerAddress + "/auth";
    private static HttpClient client = new HttpClient();

    public User Authenticated { get; private set; }

    public event Action OnAuthenticateStart;
    public event Action OnAuthenticateFail;
    public event Action OnAuthenticateSuccess;


    public async void login(Credentials credentials)
    {
        OnAuthenticateStart?.Invoke();

        var body = JsonUtility.ToJson(credentials);
        
        try
        {
            var response = await client.PostAsync(PATH, new StringContent(body));
        
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                Authenticated = (User) JsonUtility.FromJson(result, Type.GetType("User"));
                OnAuthenticateSuccess?.Invoke();
            }
            else
            {
                OnAuthenticateFail?.Invoke();
            }
        }
        catch (Exception e)
        {
            OnAuthenticateFail?.Invoke();
            Debug.LogException(e);
        }
    }
}