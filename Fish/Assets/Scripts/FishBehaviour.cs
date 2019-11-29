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
    private const float angleDelta = 6f;

    private bool firstStart = true;
    private Vector2 nextDestination;

    void Start()
    {
        transform.position = GetNewDestination();
        nextDestination = GetNewDestination();

        //transform.position = new Vector2(8, 3);
        //nextDestination = new Vector2(-8, 3);
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

        Vector3 target = new Vector3(nextDestination.x, nextDestination.y, 0);

        // Angular speed in radians per sec.
        float rotationSpeed = 1.0f;


        // Determine which direction to rotate towards
        Vector3 targetDirection = (target - transform.position).normalized;

        /*transform.rotation*/
        var lookRotation = Quaternion.LookRotation(targetDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

    }

    private static Vector2 GetNewDestination()
    {
        return new Vector2(Random.Range(-10, 10), Random.Range(-5, 5));
    }
}
