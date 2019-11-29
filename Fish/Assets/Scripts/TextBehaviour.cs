using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    Quaternion rotation;
    void Start()
    {
        rotation = new Quaternion(0, 0, 0, 0.7f);//transform.rotation;
        Debug.Log(rotation);
    }
    void LateUpdate()
    {
        transform.rotation = rotation;
    }
}
