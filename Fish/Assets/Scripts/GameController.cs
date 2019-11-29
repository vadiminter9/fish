using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject[] fish;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var f in fish)
        {
            f.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        this.GenerateFish(CrossSceneInformation.Fishes, CrossSceneInformation.Type);
    }

    void GenerateFish(Dictionary<string, int> fishes, string type)
    {
        if (type == "Count")
        {
            this.AddFishByAmount(fishes);
        }
        else if (type == "Size")
        {
            this.AddFishBySize(fishes);
        }
        else if (type == "Stage")
        {
            this.AddFishByStage(fishes);
        }
    }

    private void AddFishByAmount(Dictionary<string, int> fishTypes)
    {
        int index = 0;
        foreach (var fishType in fishTypes)
        {
            for (int k = 0; k < fishType.Value; k++)
            {
                var newFish = Instantiate(fish[index]);
                newFish.GetComponent<FishBehaviour>().Stage = -1;
                Destroy(newFish.GetComponentInChildren<TextMeshPro>());
            }
            index++;
        }
    }

    private void AddFishBySize(Dictionary<string, int> fishTypes)
    {
        double totalSum = this.GetTotalValue(fishTypes);

        float difference = 0.0125f;

        int index = 0;
        foreach (var fishType in fishTypes)
        {
            float toIncrease = (float)(0.25 + difference * GetPercent(fishType.Value, totalSum));
            fish[index].transform.localScale = new Vector3(toIncrease, toIncrease, toIncrease);

            var newFish = Instantiate(fish[index]);
            newFish.GetComponentInChildren<TextMeshPro>().text = fishType.Key;
            newFish.GetComponent<FishBehaviour>().Stage = -1;
            index++;
        }
    }

    private void AddFishByStage(Dictionary<string, int> fishTypes)
    {
        int index = 0;
        foreach (var fishType in fishTypes)
        {
            for (int k = 0; k < fishType.Value; k++)
            {
                fish[index].transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                var newFish = Instantiate(fish[index]);
                newFish.GetComponent<FishBehaviour>().Stage = Convert.ToInt32(fishType.Key);
                Destroy(newFish.GetComponentInChildren<TextMeshPro>());
            }
            index++;
        }
    }

    private int GetTotalValue(Dictionary<string, int> fishTypes)
    {
        int sum = 0;
        foreach(var fishType in fishTypes)
        {
            sum += fishType.Value;
        }

        return sum;
    }

    private double GetPercent(double value, double totalvalue)
    {
        return value / totalvalue * 100;
    }
}
