using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.SceneManagement;
using System;

public class enemyStats : MonoBehaviour
{
    public int enemyHp;
    public int damage;
    public event Action OnDeath;

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
            Destroy(gameObject);
        }
    }
}