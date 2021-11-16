using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WsClientController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MasterStore.Instance.onClientConnected += onClientConnected;
        MasterStore.Instance.onClientDisconnected += onClientDisconnected;
        
        var authenticated = AuthStore.Instance.Authenticated;
        MasterStore.Instance.Connect(authenticated.id);
    }

    private void onClientDisconnected()
    {
        Debug.Log("Client disconectado");
    }

    private void onClientConnected()
    {
        Debug.Log("Client conectado");
    }

}