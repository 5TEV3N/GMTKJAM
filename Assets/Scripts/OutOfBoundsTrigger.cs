using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsTrigger : MonoBehaviour
{
    LoseCondition loseCondition;
    private void Awake()
    {
        loseCondition = GameObject.FindGameObjectWithTag("GameManagerTag").GetComponent<LoseCondition>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            loseCondition.isFallen = true;
        }
    }
}
