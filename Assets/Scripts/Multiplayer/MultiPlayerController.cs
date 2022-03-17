using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MultiPlayerController : NetworkBehaviour
{
    public bool hasBall = true;
    public float force;
    public GameObject ball;
    public GameObject ballPrefab;
    public Transform ballSpawnPosition;
    private int playerID;
    private UIManager uIManager;
    public TextMesh playerNameText;
    public GameObject playerUIInfo;

    public Material[] blockMaterials;

    [SyncVar(hook = nameof(OnNameChanged))]
    public string playerName;

    void Awake()
    {
        uIManager = GameObject.FindObjectOfType<UIManager>();
    }

    public void SetPlayerID(int numberPlayers)
    {
        playerID = numberPlayers;
        Debug.Log(playerID);
    }

    void OnNameChanged(string _Old, string _New)
    {
        playerNameText.text = playerName;
    }

    public override void OnStartLocalPlayer()
    {
        string name = "Player " + playerID.ToString();
        CmdSetupPlayer(name);
    }


    [Command]
    public void CmdSetupPlayer(string _name)
    {
        playerName = _name;
        uIManager.statusText = $"{playerName} joined.";
    }

    [Command(requiresAuthority = false)]
    public void CmdChangeScore()
    {
        int _score = 100;
        uIManager.playerScore += _score;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }

        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 50f;
        transform.Translate(moveX, 0, 0);
        if(playerID == 1)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.5f, 9.5f), -2f, 0f);
        }
        if(playerID == 0)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.5f, 9.5f), -3f, 0f);
        }
        if(Input.GetKeyUp(KeyCode.Space) && hasBall)
        {
            CmdShootBall();
        }
    }

    [Command(requiresAuthority = false)]
    public void CmdRespawnBall()
    {
        RpcRespawnBall();
    }

    [ClientRpc]
    void RpcRespawnBall()
    {
        ball = transform.Find("ballMesh").gameObject;
        if(ball == null)
        {
            return;
        }
        ball.SetActive(true);
        hasBall = true;
    }

    [Command]
    void CmdShootBall()
    {
        RpcFireBall();
    }

    [ClientRpc]
    void RpcFireBall()
    {
        hasBall = false;
        ball = transform.Find("ballMesh").gameObject;
        if(ball == null)
        {
            return;
        }
        ball.SetActive(false);
        GameObject playerBall = Instantiate(ballPrefab, ballSpawnPosition.position, Quaternion.identity);
        playerBall.name = "ball" + playerID;
        playerBall.GetComponent<MultiplayerBall>().playerParent = this.gameObject;
        float angle = Random.Range(-force/2, force/2);
        playerBall.GetComponent<Rigidbody>().AddForce(angle, force, 0);
        Physics.SyncTransforms();
    }

    [Command(requiresAuthority = false)]
    public void CmdChangeBlockColour(GameObject _block, int _colourIndex)
    {
        SetBlockColourRpc(_block, _colourIndex);
    }

    [ClientRpc]
    public void SetBlockColourRpc(GameObject _gameBlock, int _blockColourIndex)
    {
        GameObject spawnedBlock  = _gameBlock;
        Material blockMaterial = blockMaterials[_blockColourIndex];
        spawnedBlock.GetComponent<Renderer>().material = blockMaterial;        
    }

   
}
