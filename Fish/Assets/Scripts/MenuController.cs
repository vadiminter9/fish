using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    bool IsColor = false;
    bool IsSize = false;

    public GameObject InputFieldPrefab;
    public GameObject TextPrefab;

    int index = 0;

    List<string> colors = new List<string>()
    {
        "Голубой",
        "Золотой",
        "Желтый",
        "Синий",
        "Красный",
        "Морская волна",
        "Белый",
        "Космос"
    };

    public void SetColor(bool selected)
    {
        IsColor = !IsColor;
        Debug.Log("Size is " + IsSize);
        Debug.Log("Color is " + IsColor);

        foreach (var gameObject in GameObject.FindGameObjectsWithTag("SZ"))
        {
            Destroy(gameObject);
        }

        index = 0;
    }

    public void SetSize(bool isOn)
    {
        IsSize = !IsSize;
        Debug.Log("Size is " + IsSize);
        Debug.Log("Color is " + IsColor);

        foreach (var gameObject in GameObject.FindGameObjectsWithTag("CLR"))
        {
            Destroy(gameObject);
        }

        index = 0;
    }

    public void AddField()
    {
        var panel = GameObject.Find("MenuPanel");
        var addButton = GameObject.Find("Add");
        var startButton = GameObject.Find("Start");

        if (IsColor)
        {
            if (index < 8)
            {
                var text = Instantiate(TextPrefab);
                text.transform.parent = panel.transform;
                text.transform.localPosition = new Vector3(text.transform.localPosition.x, text.transform.localPosition.y, 0);
                text.transform.localScale = new Vector3(1, 1, 1);
                text.GetComponent<Text>().text = colors[index];
                text.tag = "CLRInf";

                var inputField = Instantiate(InputFieldPrefab);
                inputField.transform.parent = panel.transform;
                inputField.transform.localPosition = new Vector3(inputField.transform.localPosition.x, inputField.transform.localPosition.y, 0);
                inputField.transform.localScale = new Vector3(1, 1, 1);
                inputField.tag = "CLR";
            }
        }
        else if (IsSize)
        {
            var text = Instantiate(TextPrefab);
            text.transform.parent = panel.transform;
            text.transform.localPosition = new Vector3(text.transform.localPosition.x, text.transform.localPosition.y, 0);
            text.transform.localScale = new Vector3(1, 1, 1);
            text.GetComponent<Text>().text = colors[index];
            text.tag = "SZInf";

            var inputField = Instantiate(InputFieldPrefab);
            inputField.transform.parent = panel.transform;
            inputField.transform.localPosition = new Vector3(inputField.transform.localPosition.x, inputField.transform.localPosition.y, 0);
            inputField.transform.localScale = new Vector3(1, 1, 1);
            inputField.tag = "SZ";
        }

        addButton.transform.SetAsLastSibling();
        startButton.transform.SetAsLastSibling();

        index++;
    }

    public void StartSimulation()
    {
        if (IsColor)
        {
            CrossSceneInformation.Type = "Count";

            var inputFieldsGameObjects = GameObject.FindGameObjectsWithTag("CLR");
            List<InputField> fields = new List<InputField>();
            foreach (var gameObject in inputFieldsGameObjects)
            {
                fields.Add(gameObject.GetComponent<InputField>());
            }

            int crossSceneInfoIndex = 0;

            foreach (var field in fields)
            {
                CrossSceneInformation.Fishes[crossSceneInfoIndex] = Convert.ToInt32(field.text);
                crossSceneInfoIndex++;
            }

            while (crossSceneInfoIndex < CrossSceneInformation.Fishes.Length)
            {
                CrossSceneInformation.Fishes[crossSceneInfoIndex] = 0;
                crossSceneInfoIndex++;
            }

        }
        else if (IsSize)
        {
            CrossSceneInformation.Type = "Size";

            var inputFieldsGameObjects = GameObject.FindGameObjectsWithTag("SZ");
            List<InputField> fields = new List<InputField>();
            foreach (var gameObject in inputFieldsGameObjects)
            {
                fields.Add(gameObject.GetComponent<InputField>());
            }

            int crossSceneInfoIndex = 0;

            foreach (var field in fields)
            {
                CrossSceneInformation.Fishes[crossSceneInfoIndex] = Convert.ToInt32(field.text);
                crossSceneInfoIndex++;
            }

            while (crossSceneInfoIndex < CrossSceneInformation.Fishes.Length)
            {
                CrossSceneInformation.Fishes[crossSceneInfoIndex] = 0;
                crossSceneInfoIndex++;
            }
        }

        SceneManager.LoadScene("SampleScene");
        Debug.Log("Loaded scene");
    }
}
