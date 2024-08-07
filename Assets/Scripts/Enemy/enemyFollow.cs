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


    [SerializeField]
    float range;
    [SerializeField]
    float maxX1;
    [SerializeField]
    float maxX2;
    [SerializeField]
    float maxY1;
    [SerializeField]
    float maxY2;

    Vector2 wayPoint;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        SetNewDestination();
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

        else if(distanceFromPlayer > lineOfSite)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, wayPoint) <= range)
            {
                SetNewDestination();
            }
        }
    }

    void SetNewDestination()
    {
        wayPoint = new Vector2(UnityEngine.Random.Range(maxX1, maxX2), UnityEngine.Random.Range(maxY1, maxY2));
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }

}
