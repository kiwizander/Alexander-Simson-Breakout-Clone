using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleplayerBall : MonoBehaviour
{
    public bool parented = false;
    public GameObject playerParent;
    public SingleUIManager uIManager;

    void Start()
    {
        uIManager = GameObject.FindObjectOfType<SingleUIManager>();
    }

    void OnCollisionEnter(Collision other)
    {
        GameObject otherObject = other.gameObject;
        if(otherObject.tag == "block")
        {
            Destroy(otherObject);
            uIManager.score += 100;
            uIManager.ChangeScore();
        }
    }
}
