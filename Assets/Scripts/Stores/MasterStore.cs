using System;
using Stores;
using UnityEngine;
using WebSocketSharp;

public class MasterStore : Singleton<MasterStore>
{
    private static readonly string PATH = AppStore.Instance
        .ServerAddress.Replace("http", "ws")
        .Replace("3000", "8080");
    
    private static WebSocket client; 
    
    public event Action onClientConnected;
    public event Action onClientDisconnected;
    // public event Action OnAuthenticateSuccess;


    public void Connect(String id)
    {
        client = new WebSocket(PATH + "/" + id);
        client.OnMessage += onMatchMessage;
        client.OnOpen += onOpen;
        client.OnClose += OnClose;
        
        client.Connect();
    }

    private void onOpen(object sender, EventArgs e)
    {
        onClientConnected?.Invoke();
    }  
    
    private void OnClose(object sender, EventArgs e)
    {
        onClientDisconnected?.Invoke();
    }

    private void onMatchMessage(object sender, MessageEventArgs e)
    {
        Debug.Log("Message: " + e.Data);
    }
}