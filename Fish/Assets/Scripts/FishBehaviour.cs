using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class FishBehaviour : MonoBehaviour
{
    System.Random random = new System.Random();
    public float speed = 1;
    private const float destinationDelata = 3f;

    private bool firstStart = true;
    private Vector2 nextDestination;

    void Start()
    {
        nextDestination = GetNewDestination();
    }

    void Update()
    {
        float dx = nextDestination.x - transform.position.x;
        float dy = nextDestination.y - transform.position.y;

        bool gotPosition = Math.Abs(dx) < destinationDelata &&
             Math.Abs(dy) < destinationDelata;

        if (gotPosition)
        {
            this.nextDestination = GetNewDestination();
        }

        float alpha = (float)Math.Atan2(dy, dx);

        Vector2 position = transform.position;

        var xMove = speed * (float)Math.Cos(alpha) * Time.deltaTime;
        position.x = position.x + xMove;

        var yMove = speed * (float)Math.Sin(alpha) * Time.deltaTime;
        position.y = position.y + yMove;
        transform.position = position;
    }

    private static Vector2 GetNewDestination()
    {
        return new Vector2(Random.Range(-10, 10), Random.Range(-5, 5));
    }
}
