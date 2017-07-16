using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    public bool isFound;
    public bool isFallen;
    TimeLeft timeLeft;

    private void Awake()
    {
        timeLeft = GameObject.FindGameObjectWithTag("UITag").GetComponent<TimeLeft>();
    }

    private void FixedUpdate()
    {
        if (isFallen == true)
        {
            Time.timeScale = 0;
            Debug.Log("Game lost due to falling out of bounds");
        }

        if (isFound == true)
        {
            Time.timeScale = 0;
            Debug.Log("Game lost due to being in contact with an enemy");
        }

        if (timeLeft.timer <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("Game lost due to no time left");
        }

    }

}
