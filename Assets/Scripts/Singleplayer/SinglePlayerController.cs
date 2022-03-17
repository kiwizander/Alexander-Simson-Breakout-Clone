using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerController : MonoBehaviour
{
    public bool hasBall = true;
    public float force;
    public GameObject ball;
    public GameObject ballPrefab;
    public Transform ballSpawnPosition;
    private int playerID;
    private SingleUIManager uIManager;
    public TextMesh playerNameText;
    public GameObject playerUIInfo;

    void Awake()
    {
        uIManager = GameObject.FindObjectOfType<SingleUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 50f;
        transform.Translate(moveX, 0, 0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.5f, 9.5f), -2f, 0f);
        if(Input.GetKeyUp(KeyCode.Space) && hasBall)
        {
            FireBall();
        }
    }

    public void RespawnBall()
    {
        ball = transform.Find("ballMesh").gameObject;
        if(ball == null)
        {
            return;
        }
        ball.SetActive(true);
        hasBall = true;
    }

    void FireBall()
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
        playerBall.GetComponent<SingleplayerBall>().playerParent = this.gameObject;
        float angle = Random.Range(-force/2, force/2);
        playerBall.GetComponent<Rigidbody>().AddForce(angle, force, 0);
    }
}
