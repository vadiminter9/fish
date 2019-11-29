using System.Collections;
using System.Collections.Generic;
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

    void GenerateFish(int[] fishes, string type)
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

    private void AddFishByAmount(int[] fishes)
    {
        for (int i = 0; i < fishes.Length; i++)
        {
            for (int j = 0; j < fishes[i]; j++)
            {
                Instantiate(fish[i]);
            }
        }
    }

    private void AddFishBySize(int[] fishes)
    {
        double totalSum = this.GetTotalValue(fishes);

        float difference = 0.0125f;

        for (int i = 0; i < fishes.Length; i++)
        {
            if (fishes[i] != 0)
            {
                float toIncrease = (float)(0.25 + difference * GetPercent(fishes[i], totalSum));
                fish[i].transform.localScale = new Vector3(toIncrease, toIncrease, toIncrease);
                Instantiate(fish[i]);
            }
        }
    }

    private double GetTotalValue(int[] fishes)
    {
        double sum = 0;
        foreach(int fish in fishes)
        {
            sum += fish;
        }

        return sum;
    }

    private double GetPercent(double value, double totalvalue)
    {
        return value / totalvalue * 100;
    }
}
