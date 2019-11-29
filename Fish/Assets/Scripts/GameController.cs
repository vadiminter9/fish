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
        else
        {
            this.AddFishBySize(fishes);
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
