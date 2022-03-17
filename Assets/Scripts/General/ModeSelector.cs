using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelector : MonoBehaviour
{

    public void SinglePlayer()
    {
        SceneManager.LoadScene("Singleplayer", LoadSceneMode.Single);
    }

    public void MultiPlayer()
    {
        SceneManager.LoadScene("Multiplayer", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
