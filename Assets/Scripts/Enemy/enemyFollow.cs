using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyFollow : MonoBehaviour
{
    private Transform player;
    public float speed;
    public float distance;
    public float lineOfSite;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        if (distanceFromPlayer < lineOfSite) 
        {
            if (distance > 1.5)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }

}
