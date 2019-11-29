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

        List<Group> groups = new List<Group>
        {
            new Group("Group 1", 15),
            new Group("Group 2", 2),
            new Group("Group 3", 7)
        };

        this.GenerateFish(groups, Type.Size);
    }

    void GenerateFish(List<Group> groups, Type type)
    {
        if (type == Type.Amount)
        {
            this.AddFishByAmount(groups);
        }
        else
        {
            this.AddFishBySize(groups);
        }
    }

    private void AddFishByAmount(List<Group> groups)
    {
        for (int i = 0; i < groups.Count; i++)
        {
            for (int j = 0; j < groups[i].Value; j++)
            {
                Instantiate(fish[i]);
            }
        }
    }

    private void AddFishBySize(List<Group> groups)
    {
        double totalSum = this.GetTotalValue(groups);

        float difference = 0.0125f;

        for (int i = 0; i < groups.Count; i++)
        {
            float toIncrease = (float)(0.25 + difference * GetPercent(groups[i].Value, totalSum));
            fish[i].transform.localScale = new Vector3(toIncrease, toIncrease, toIncrease);
            Instantiate(fish[i]);
        }
    }

    private double GetTotalValue(List<Group> groups)
    {
        double sum = 0;
        foreach(Group group in groups)
        {
            sum += group.Value;
        }

        return sum;
    }

    private double GetPercent(double value, double totalvalue)
    {
        return value / totalvalue * 100;
    }
}

public class Group
{
    public Group(string name, int amount)
    {
        this.Name = name;
        this.Value = amount;
    }

    public string Name { get; set; }

    public double Value { get; set; }
}

public enum Type
{
    Amount,
    Size
}
