using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FishBehaviour : MonoBehaviour
{
    System.Random random = new System.Random();
    public float speed = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*float horizontal = Random.Next();
		float vertical = Random.Next();
       float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");*/

        Vector2 position = transform.position;
        position.x = position.x + speed * (float)random.NextDouble() * Time.deltaTime;
        position.y = position.y + speed * (float)random.NextDouble() * Time.deltaTime;
        transform.position = position;
    }
}
