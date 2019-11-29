using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class FishBehaviour : MonoBehaviour
{
    System.Random random = new System.Random();
    public float speed = 1;
    private const float destinationDelata = 1.5f;
    private const float angleDelta = 6f;

    private bool firstStart = true;
    private Vector3 nextDestination;

    bool isEating = false;
    GameObject currentFood;

    public int Stage;

    void Start()
    {
        transform.position = GetNewDestination();
        nextDestination = GetNewDestination();

        //transform.position = new Vector2(8, 3);
        //nextDestination = new Vector2(-8, 3);
    }

    void Update()
    {
        GameObject[] feeds = GameObject.FindGameObjectsWithTag("FEED");

        if (feeds.Length > 0)
        {
            if (!isEating)
            {
                currentFood = feeds[random.Next(0, feeds.Length)];
            }
            if (currentFood != null && currentFood.transform.position.y > -4.2)
            {
                if (currentFood.transform.position.y < -3.0)
                { this.nextDestination = currentFood.transform.position; }
                else
                {
                    this.nextDestination = currentFood.transform.position + new Vector3(0, 1.5f, 0);
                }
            }
            else
            {
                isEating = false;
            }

            isEating = true;
            speed = 3;
        }

        float dx = nextDestination.x - transform.position.x;
        float dy = nextDestination.y - transform.position.y;
        //float dz = nextDestination.z - transform.position.z;

        bool gotPosition = Math.Abs(dx) < destinationDelata &&
             Math.Abs(dy) < destinationDelata;

        if (gotPosition)
        {           
            if (currentFood != null)
            {
                Destroy(currentFood);
            }

            this.nextDestination = GetNewDestination();
            isEating = false;
            speed = 1;
        }

        float alpha = (float)Math.Atan2(dy, dx);
        //float cosBeta = (float)Math.Cos(Math.Abs(dz) / (Math.Sqrt(dx * dx + dy * dy + dz * dz)));

        Vector3 position = transform.position;

        var xMove = speed * (float)Math.Cos(alpha) * Time.deltaTime;
        position.x = position.x + xMove;

        var yMove = speed * (float)Math.Sin(alpha) * Time.deltaTime;
        position.y = position.y + yMove;

        //var zMove = speed * cosBeta * Time.deltaTime;
        //position.z = position.z + zMove;

        transform.position = position;

        Vector3 target = new Vector3(nextDestination.x, nextDestination.y, position.z);

        // Angular speed in radians per sec.
        float rotationSpeed = 1.0f;


        // Determine which direction to rotate towards
        Vector3 targetDirection = (target - transform.position).normalized;

        /*transform.rotation*/
        var lookRotation = Quaternion.LookRotation(targetDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

    }

    private Vector3 GetNewDestination()
    {
        if (Stage == -1)
        {
            return new Vector3(Random.Range(-10, 14), Random.Range(-3, 7), Random.Range(-8, 5));
        }
        return new Vector3(Random.Range(-10, 14), Random.Range(-3.5f + 2.5f * (Stage - 1), -3.5f + 2.5f * Stage), Random.Range(-8, 5));
    }
}
