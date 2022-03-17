using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MultiplayerFloorTrigger : NetworkBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        GameObject otherObject = other.gameObject;
        if(otherObject.tag == "ball")
        {
            GameObject ballParent = otherObject.GetComponent<MultiplayerBall>().playerParent;
            ballParent.GetComponent<MultiPlayerController>().CmdRespawnBall();
            DestroyBall(otherObject);            
        }
    }

    [ServerCallback]
    void DestroyBall(GameObject _object)
    {
        NetworkServer.Destroy(_object);
    }
}
