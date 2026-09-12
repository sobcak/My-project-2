using System.Collections.Generic;
using UnityEngine;

public class HumanManagerScript : MonoBehaviour
{
    public List<Human> humanRegistry = new List<Human>();

    void Start()
    {
        transform.position = new Vector2(5015, 5015);

        // Populate
        for (int i = 0; i < 5; i++)
        {
            CreateHuman();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered overlap with: " + other.name);
        Debug.Log(DataStorage.Instance.NumberOfHumans + " Human number of humans");

        KillOldHuman();
        Age();
        HaveKids();
    }

    void CreateHuman()
    {
        Human human = new Human();
        humanRegistry.Add(human);
        DataStorage.Instance.NumberOfHumans = humanRegistry.Count;
    }

    void KillOldHuman()
    {
        humanRegistry.RemoveAll(human => human.CurrentAge >= human.MaxAge);
        DataStorage.Instance.NumberOfHumans = humanRegistry.Count;
    }

    void Age()
    {
        foreach (Human human in humanRegistry)
        {
            human.CurrentAge++;
        }
    }

    void HaveKids()
    {
        Debug.Log("Kids Reached");
        
        float foodRequirement = DataStorage.Instance.NumberOfHumans * 1.2f;
        float housingRequirement = DataStorage.Instance.NumberOfHumans * 1.1f;

        if (DataStorage.Instance.AvailableFood > foodRequirement && 
            DataStorage.Instance.AvailableHousing > housingRequirement)
        {
            int pairs = DataStorage.Instance.NumberOfHumans / 2;
            for (int i = 0; i < pairs; i++)
            {
                int kid = Random.Range(0, 9);
                if (kid == 8)
                {
                    CreateHuman();
                }
            }
        }
    }
}