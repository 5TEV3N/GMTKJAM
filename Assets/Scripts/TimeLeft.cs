using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLeft : MonoBehaviour
{
    public Text timeLeftContainer;
    public float timer;
    public bool frozenTime;
    public Color freezeColor;
    private Color originalColor;

    private void Start()
    {
        originalColor = timeLeftContainer.color;
    }

    private void FixedUpdate()
    {
        if (frozenTime == false)
        {
            timeLeftContainer.color = originalColor;
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer - minutes * 60);
            string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            timeLeftContainer.text = "Time Left" + "\n" + niceTime;
            timer -= Time.deltaTime;
        }
        else
        {
            timeLeftContainer.color = freezeColor;
        }
    }
}
