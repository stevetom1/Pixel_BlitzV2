using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class enemyStats : MonoBehaviour
{
    public int enemyHp;
    public int damage;
    public event Action OnDeath;
    public GameObject bluSlime;
    public GameObject fireSlime;
    public GameObject lavaSlime;
    public GameObject earthSlime;
    public GameObject electroSlime;

    public GameObject lavaPool;

    private EnemySpawner enemySpawner;
    private ExpirienceManager expirienceManager;
    private Data data;

    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        expirienceManager = FindObjectOfType<ExpirienceManager>();
        data = FindObjectOfType<Data>();

        if (expirienceManager == null)
        {
            Debug.LogError("ExpirienceManager not found!");
        }
    }

    void Update()
    {

    }


    public void TakeDamage()
    {
        enemyHp -= (damage + data.currentLevel);
        Debug.Log("hp slime: " + enemyHp);

        if (enemyHp <= 0)
        {
            OnDeath?.Invoke();
            if (gameObject == fireSlime)
            {
                GameObject lavaPoolSpawn = Instantiate(lavaPool, transform.position, Quaternion.identity);
                enemySpawner.OnEnemyDestroyed(200);
                expirienceManager.AddExperience(10);
            }
            Destroy(gameObject);
            if (gameObject == bluSlime)
            {
                enemySpawner.OnEnemyDestroyed(100);
                expirienceManager.AddExperience(5);
            }
            if (gameObject == earthSlime)
            {
                enemySpawner.OnEnemyDestroyed(300);
                expirienceManager.AddExperience(15);
            }
            if (gameObject == electroSlime)
            {
                enemySpawner.OnEnemyDestroyed(350);
                expirienceManager.AddExperience(20);
            }
            if (gameObject == lavaSlime)
            {
                enemySpawner.OnEnemyDestroyed(500);
                expirienceManager.AddExperience(25);
            }
        }
    }
}