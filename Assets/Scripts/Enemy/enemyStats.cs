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
    public GameObject fireSlime;
    public GameObject lavaPool;

    void Start()
    {

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
            if(gameObject == fireSlime) 
            {
                GameObject lavaPoolSpawn = Instantiate(lavaPool, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}