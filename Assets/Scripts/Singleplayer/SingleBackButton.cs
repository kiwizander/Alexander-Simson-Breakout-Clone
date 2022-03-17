using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleBackButton : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }
}
