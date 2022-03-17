using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
public class GameManagerBreakOut : MonoBehaviour
{
    public Transform playerSpawnPosition;

    public GameObject ball;
    public GameObject block;

    public GameObject playerPrefab;

    public GameObject blockHolder;

    public Material[] materials;

    public void Start()
    {
        SpawnBlocks();
        GameObject player = Instantiate(playerPrefab, playerSpawnPosition.position, Quaternion.identity);
    }

    public void SpawnBlocks()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject newBlock = Instantiate(block, new Vector3(i, j, 0), Quaternion.identity);
                newBlock.GetComponent<Renderer>().material = materials[j];
            }
        }
    }
}
