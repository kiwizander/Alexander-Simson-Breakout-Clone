using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;


public class MultiplayerBack : NetworkBehaviour
{
    NetworkManagerBreakOut networkManagerBreakOut;
    void Start()
    {
        networkManagerBreakOut = GameObject.FindObjectOfType<NetworkManagerBreakOut>();        
    }
    public void Back()
    {
        if(!isServer)
        {
            networkManagerBreakOut.StopClient();
        }
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }
}
