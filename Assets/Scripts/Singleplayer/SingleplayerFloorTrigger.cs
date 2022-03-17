using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SingleplayerFloorTrigger : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        GameObject otherObject = other.gameObject;
        if(otherObject.tag == "ball")
        {
            GameObject ballParent = otherObject.GetComponent<SingleplayerBall>().playerParent;
            ballParent.GetComponent<SinglePlayerController>().RespawnBall();
            Destroy(otherObject);          
        }
    }
}
