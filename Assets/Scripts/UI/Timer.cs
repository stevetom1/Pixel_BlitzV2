using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    public TextMeshProUGUI timeCounter;
    public string playerName = "Player"; // Set dynamically as needed

    private TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timeCounter.text = "Time: 00:00.0";
        Debug.Log("Timer initialized");
    }

    private void Update()
    {
        Debug.Log("èas" + elapsedTime);

        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            //Debug.Log("Updating elapsed time: " + elapsedTime + " seconds");

            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
        }
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;
        Debug.Log("Timer started");
        //StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
        Debug.Log("Timer stopped. Elapsed Time: " + elapsedTime + " seconds");
    }

    public IEnumerator UpdateTimer()
    {
        Debug.Log("UpdateTimer coroutine started");
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            //Debug.Log("Updating elapsed time: " + elapsedTime + " seconds");

            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
            yield return null;
        }
    }

    public float GetElapsedTime()
    {
        Debug.Log("Returning elapsed time: " + elapsedTime + " seconds");
        return elapsedTime;
    }
}
