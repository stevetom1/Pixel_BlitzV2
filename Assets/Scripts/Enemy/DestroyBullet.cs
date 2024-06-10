using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class DestroyBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public event Action EnemyHit;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyStats enemyStatsComponent = collision.gameObject.GetComponent<enemyStats>();

            if (enemyStatsComponent != null)
            {
                enemyStatsComponent.TakeDamage();
            }

            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
