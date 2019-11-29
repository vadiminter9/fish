using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject[] fish;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<15; i++)
		{
			Instantiate(fish[i]);
		}
    }

    /*// Update is called once per frame
    void Update()
    {
        
    }*/
}
