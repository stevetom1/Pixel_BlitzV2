using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /*
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int maxEnemies = 7;
    public int totalEnemies = 15;
    public bool canSpawn = true;

    private int currentEnemyCount = 0;
    private int totalEnemiesDefeated = 0;

    public event System.Action<int> OnEnemyDefeated;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (currentEnemyCount < totalEnemies)
        {
            if (currentEnemyCount < maxEnemies)
            {
                SpawnEnemy();
                currentEnemyCount++;
            }

            yield return null;
        }

        if (OnEnemyDefeated != null)
        {
            OnEnemyDefeated.Invoke(totalEnemiesDefeated);
        }
    }

    void SpawnEnemy()
    {
        if (canSpawn == true)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            enemyStats enemyHealth = newEnemy.GetComponent<enemyStats>();
            if (enemyHealth != null)
            {
                enemyHealth.OnDeath += () => HandleEnemyDeath(newEnemy);
            }
        }
    }

    void HandleEnemyDeath(GameObject enemy)
    {
        currentEnemyCount++;
        totalEnemiesDefeated++;

        if (gameManager != null)
        {
            gameManager.PlayerGainXP(10);
        }

        if (totalEnemiesDefeated >= totalEnemies)
        {
            StopCoroutine(SpawnEnemies());
            canSpawn = false;
        }
    }
    */


    public List<Enemy> enemies= new List<Enemy>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public int currWave;
    public int waveValue;
    public Transform spawnlocation;
    public int waveDuration;

    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    private void Start()
    {
        GenerateWave();
    }

    private void FixedUpdate()
    {
        if(spawnTimer <= 0) 
        {
            if(enemiesToSpawn.Count > 0 )
            {
                Instantiate(enemiesToSpawn[0], spawnlocation.position, Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;
            }
            else
            {
                waveTimer = 0;
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
        while(waveValue > 0)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if(waveValue - randEnemyCost >= 0 )
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if(waveValue <= 0)
            {
                break;
            }
        }

        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;

    }

}

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}