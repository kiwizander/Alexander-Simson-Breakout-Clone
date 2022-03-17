using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MultiplayerBall : NetworkBehaviour
{

    //Unfortunatley the ball physics doesn't quite sync up and the ball doesn't delete correctly on the client
    public bool parented = false;
    public GameObject playerParent;
    public UIManager uIManager;

    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.FindObjectOfType<UIManager>();
    }

    void OnCollisionEnter(Collision other)
    {
        GameObject otherObject = other.gameObject;
        if(otherObject.tag == "block")
        {
            DestroyBlock(otherObject);
            playerParent.GetComponent<MultiPlayerController>().CmdChangeScore();
        }
    }

    [ServerCallback]
    void DestroyBlock(GameObject _object)
    {
        NetworkServer.Destroy(_object);
    }


}
