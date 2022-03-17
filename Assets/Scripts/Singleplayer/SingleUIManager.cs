using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleUIManager : MonoBehaviour
{
    // public Text statusTextBar;
    public Text scoreTextBar;
    public int score;

    public void ChangeScore()
    {
        scoreTextBar.text = "Score: " + score.ToString();
    }
}
