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
    public GameObject earthSlime;
    public GameObject lavaPool;

    private EnemySpawner enemySpawner;

    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Update()
    {

    }


    public void TakeDamage()
    {
        enemyHp -= damage;

        if (enemyHp <= 0)
        {
            OnDeath?.Invoke();
            if (gameObject == fireSlime)
            {
                GameObject lavaPoolSpawn = Instantiate(lavaPool, transform.position, Quaternion.identity);
                enemySpawner.OnEnemyDestroyed(200);
            }
            Destroy(gameObject);
            if (gameObject == bluSlime)
            {
                enemySpawner.OnEnemyDestroyed(100);
            }
            if (gameObject == earthSlime)
            {
                enemySpawner.OnEnemyDestroyed(300);
            }
        }
    }
}