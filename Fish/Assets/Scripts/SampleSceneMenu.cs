using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleSceneMenu : MonoBehaviour
{

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuScene");
        }
        /*Vector3 screenPosition = Event.current.mousePosition;
        screenPosition.y = Camera.current.pixelHeight - screenPosition.y;
        Ray ray = Camera.current.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Event.current.Use();
        }*/
        
    }
}
