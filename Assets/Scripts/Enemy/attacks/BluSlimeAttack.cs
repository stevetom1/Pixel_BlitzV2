using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluSlimeAttack : MonoBehaviour
{
    private Transform player;
    public float distance;
    public float lineOfSite;

    public GameObject bulletPrefab;
    public float[] angles = { 0, 45, 90, 135, 180, 225, 270, 315 };
    public float bulletSpeed = 5.0f;
    public float spawnRate = 0.5f;
    private float timer = 0.0f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;

    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distanceFromPlayer < lineOfSite)
        {
            timer += Time.deltaTime;

            if (timer >= spawnRate)
            {
                timer = 0.0f;

                foreach (float angle in angles)
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    
                    Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);

                    bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                }
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }

}