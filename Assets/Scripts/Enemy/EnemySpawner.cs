using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
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
}
