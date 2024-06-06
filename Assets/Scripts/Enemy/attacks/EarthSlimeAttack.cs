using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSlimeAttack : MonoBehaviour
{
    public float distance;
    public float lineOfSite;

    public GameObject bulletPrefab;
    public int numBullets = 20;
    public float bulletSpread = 45f;
    public float fireRate = 1f;
    private Transform player;

    private float timer;

    private void Start()
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

            if (timer >= fireRate)
            {
                timer = 0f;

                for (int i = 0; i < numBullets; i++)
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    Vector2 direction = (Vector2)player.transform.position - (Vector2)transform.position;
                    float angle = Random.Range(-bulletSpread, bulletSpread);
                    direction = Quaternion.AngleAxis(angle, Vector3.forward) * direction;
                    bullet.GetComponent<Rigidbody2D>().velocity = direction * 1;
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
