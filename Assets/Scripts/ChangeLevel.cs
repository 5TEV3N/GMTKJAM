using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public GameObject levelContainer;
    Respawn respawn;

    private void Awake()
    {
        respawn = GameObject.FindGameObjectWithTag("GameManagerTag").GetComponent<Respawn>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            levelContainer.SetActive(false);
            respawn.playerSpawnLocation++;
        }
    }
}
