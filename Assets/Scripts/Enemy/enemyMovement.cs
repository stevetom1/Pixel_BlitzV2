using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
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
        SetNewDestination();
    }



    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoint) < range)
        {
            SetNewDestination();
        }

    }
    void SetNewDestination()
    {
        wayPoint = new Vector2(UnityEngine.Random.Range(maxX1, maxX2), UnityEngine.Random.Range(maxY1, maxY2));
    }
}