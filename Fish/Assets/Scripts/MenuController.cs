using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    bool IsColor = false;
    bool IsSize = false;

    public GameObject InputFieldPrefab;
    public GameObject TextPrefab;
    public GameObject SizePanel;

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
        var startButton = GameObject.Find("Run");

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
            if (index < 8)
            {
                var sizePanel = Instantiate(SizePanel);
                sizePanel.transform.parent = panel.transform;
                sizePanel.transform.localPosition = new Vector3(sizePanel.transform.localPosition.x, sizePanel.transform.localPosition.y, 0);
                sizePanel.transform.localScale = new Vector3(1, 1, 1);
                sizePanel.GetComponentInChildren<Text>().text = colors[index];
                sizePanel.GetComponentsInChildren<InputField>().Where(x => x.tag == "Name").First().placeholder.GetComponent<Text>().text = "Name";
                sizePanel.GetComponentsInChildren<InputField>().Where(x => x.tag == "SZ").First().placeholder.GetComponent<Text>().text = "Size";
            }
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

            var colorInputFields = GameObject.FindObjectsOfType<InputField>().Where(x => x.tag == "CLR");

            var iteration = 0;
            foreach (var field in colorInputFields)
            {
                CrossSceneInformation.Fishes.Add(colors[iteration], Convert.ToInt32(field.text));
                iteration++;
            }
        }
        else if (IsSize)
        {
            CrossSceneInformation.Type = "Size";

            var sizePanels = GameObject.FindGameObjectsWithTag("SizePanel");

            foreach (var panel in sizePanels)
            {
                string name = panel.GetComponentsInChildren<InputField>().Where(x => x.tag == "Name").FirstOrDefault().text;
                var sizeInputValue = panel.GetComponentsInChildren<InputField>().Where(x => x.tag == "SZ").FirstOrDefault().text;
                int size = Convert.ToInt32(sizeInputValue);
                CrossSceneInformation.Fishes.Add(name, size);
            }
        }

        SceneManager.LoadScene("SampleScene");
        Debug.Log("Loaded scene");
    }
}
