using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public int currWave;
    public int waveValue;
    public Transform spawnlocation;
    public int waveDuration;
    public int totalPoints;

    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    [SerializeField] public TextMeshProUGUI scoreText;
    public GameObject victoryScreen;

    private List<GameObject> activeEnemies = new List<GameObject>();

    private void Start()
    {
        GenerateWave();
    }

    private void FixedUpdate()
    {
        if (spawnTimer <= 0)
        {
            if (enemiesToSpawn.Count > 0)
            {
                GameObject newEnemy = Instantiate(enemiesToSpawn[0], spawnlocation.position, Quaternion.identity);
                activeEnemies.Add(newEnemy);
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;
            }
            else
            {
                waveTimer = 0;
                CheckEnemiesDefeated();
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
    }

    public void GenerateWave()
    {
        waveValue = currWave * 10;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count;
        waveTimer = waveDuration;
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if (waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }

        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

    private void CheckEnemiesDefeated()
    {
        activeEnemies.RemoveAll(enemy => enemy == null);
        if (activeEnemies.Count == 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        victoryScreen.SetActive(true);
        Time.timeScale = 0f;

        SaveScore();
        Debug.Log("Leaderboard saved to: " + Application.persistentDataPath);
    }

    public void OnEnemyDestroyed(int points)
    {
        totalPoints += points;
        scoreText.text = "Score: " + totalPoints;
        CheckEnemiesDefeated();
    }

    private void SaveScore()
    {
        string playerName = "PlayerName";
        LeaderboardManager.instance.AddScore(playerName, totalPoints);
    }
}

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}
