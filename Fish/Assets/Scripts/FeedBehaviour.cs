using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBehaviour : MonoBehaviour
{
    double speed;
    Vector3 previousPosition;
    

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FEED")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<SphereCollider>());
        }

        if (collision.gameObject.tag == "FISH")
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

        //transform.position = new Vector3(transform.position.x, (float)(transform.position.y - 2 * Time.deltaTime), transform.position.z);

        //var speed = (transform.position - previousPosition).magnitude;
        //previousPosition = transform.position;

        //if (speed > 3)
        //{
            
        //}
    }
}
