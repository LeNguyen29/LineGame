using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerScript : MonoBehaviour
{
    public static TimerScript INSTANCE;

    public Text timerText;

    private TimeSpan timeSpan;

    private bool isTiming;
    private float elapsedTime;

    private void Awake()
    {
        INSTANCE = this;
    }

    private void Start()
    {
        timerText.text = "Time:\n00:00";

        StartTimer();
    }

    public void StartTimer()
    {
        isTiming = true;
        elapsedTime = 0f;

        StartCoroutine(runTimer());
    }

    public void StopTimer()
    {
        isTiming = false;
    }

    private IEnumerator runTimer()
    {
        while (isTiming)
        {
            elapsedTime += Time.deltaTime;
            timeSpan = TimeSpan.FromSeconds(elapsedTime);
            string timeSpanStr = "Time:\n" + timeSpan.ToString("hh':'mm':'ss");
            timerText.text = timeSpanStr;

            yield return null;
        }
    }
}
