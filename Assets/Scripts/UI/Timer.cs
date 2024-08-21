using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    public TextMeshProUGUI timeCounter;
    public string playerName = "Player";

    private TimeSpan timePlaying;
    private bool timerGoing;

    public static float elapsedTime;
    public float finalTime;

    private EnemySpawner enemySpawner;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        timeCounter.text = "Time: 00:00.0";
    }

    void Update()
    {
        if (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
            finalTime = elapsedTime;
            //Debug.Log(finalTime);
        }
        //Debug.Log(elapsedTime + "from update");
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        //StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
        //finalTime = elapsedTime;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }

    public float GetElapsedTime()
    {
        Debug.Log(finalTime);
        return finalTime;
    }    
}
