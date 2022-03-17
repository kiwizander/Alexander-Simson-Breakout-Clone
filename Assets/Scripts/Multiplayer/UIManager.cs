using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class UIManager : NetworkBehaviour
{
    public Text statusTextBar;
    public Text scoreTextBar;

     
    
    [SyncVar(hook = nameof(OnScoreChanged))]
    public int playerScore;

    [SyncVar(hook = nameof(OnStatusTextChanged))]
    public string statusText;

    [SyncVar(hook = nameof(OnScoreTextChanged))]
    public string scoreText;


    void OnStatusTextChanged(string _Old, string New)
    {
        statusTextBar.text = statusText;
    }

    void OnScoreTextChanged(string _Old, string New)
    {
        scoreTextBar.text = scoreText;
    }

    void OnScoreChanged(int _Old, int New)
    {
        scoreTextBar.text = "Score:" + playerScore.ToString();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
