using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBehaviour : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "FISH")
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        if(transform.position.y < -4.2 || transform.position.y > 6.4)
        {
            Destroy(gameObject);
        }
    }
}
