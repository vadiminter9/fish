using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedScript : MonoBehaviour
{
    public GameObject feed;
    System.Random random = new System.Random();
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("spawn");
            var gameObject = Instantiate(feed);


            Vector3 screenPosition = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(screenPosition);
            RaycastHit hit;

            if (Physics.Raycast(castPoint, out hit))
            {
                gameObject.transform.position = new Vector3(hit.point.x + (float)random.NextDouble(), hit.point.y + (float)(random.NextDouble()), -0.29f);
            }
        }
    }
}
