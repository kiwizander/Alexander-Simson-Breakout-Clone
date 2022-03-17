using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[AddComponentMenu("")]
public class NetworkManagerBreakOut : NetworkManager
{
    public Transform topSpawnPosition;
    public Transform bottomSpawnPosition;

    public Transform defaultTransform;
    public GameObject ball;
    public GameObject block;

    public GameObject blockHolder;


    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        // add player at correct spawn position
        Transform start = numPlayers == 0 ? bottomSpawnPosition : topSpawnPosition;
        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);
        player.GetComponent<MultiPlayerController>().SetPlayerID(numPlayers);
        if(numPlayers == 2)
        {
            SpawnBlocks(player.GetComponent<MultiPlayerController>());
        }
    }

    public void SpawnBlocks(MultiPlayerController _player)
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject newBlock = Instantiate(block, new Vector3(i, j, 0), Quaternion.identity);
                NetworkServer.Spawn(newBlock);
                _player.CmdChangeBlockColour(newBlock, j);
            }
        }
    }



    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        base.OnServerDisconnect(conn);
    }
}
