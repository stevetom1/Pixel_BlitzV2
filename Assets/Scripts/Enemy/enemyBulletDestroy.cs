using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletDestroy : MonoBehaviour
{
    public GameObject bulletPrefab;
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("environment") || collision.gameObject.CompareTag("player") || collision.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }
}
