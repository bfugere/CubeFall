using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public Text timeCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        timerGoing = false;
        BeginTimer();
    }
    
    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }
    
    public void EndTimer()
    {
        timerGoing = false;
        string timePlayingStr = "Final Time:" + "\n" + timePlaying.ToString("mm':'ss'.'ff");
        timeCounter.text = timePlayingStr;
        timeCounter.color = Color.yellow;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Survived:" + "\n" + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }
}
