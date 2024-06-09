using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerEndless : MonoBehaviour
{
    public List<EndlessEnemy> enemies = new List<EndlessEnemy>();
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
        currWave = 1;
        GenerateWave();
    }

    private void FixedUpdate()
    {
        if (waveTimer <= 0)
        {
            GenerateWave();
        }

        if (spawnTimer <= 0)
        {
            if (enemiesToSpawn.Count > 0)
            {
                Instantiate(enemiesToSpawn[0], spawnlocation.position, Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
        }

        waveTimer -= Time.fixedDeltaTime;
    }

    public void GenerateWave()
    {
        currWave++;
        waveValue = currWave * 10;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count;
        waveTimer = waveDuration;
        spawnTimer = 0;
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
        enemiesToSpawn.AddRange(generatedEnemies);
    }
}

[System.Serializable]
public class EndlessEnemy
{
    public GameObject enemyPrefab;
    public int cost;
}
