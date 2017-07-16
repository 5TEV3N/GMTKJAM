using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Respawn : MonoBehaviour
{
    public Transform respawn0;
    public Transform respawn1;
    public Transform respawn2;
    public GameObject player;
    
    public int playerSpawnLocation;

    public void GoBackToRespawn()
    {

        if (playerSpawnLocation == 0)
        {
            player.transform.position = respawn0.transform.position;
        }
        if (playerSpawnLocation == 1)
        {
            player.transform.position = respawn1.transform.position;
        }
        if (playerSpawnLocation == 2)
        {
            player.transform.position = respawn2.transform.position;
        }
    }
}
