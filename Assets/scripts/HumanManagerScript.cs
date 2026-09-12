using System.Collections.Generic;
using System.Linq;
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

        KillOldHuman();
        Age();
        HaveKids();
    }

    void CreateHuman()
    {
        Human human = new Human();
        human.Initialize();
        humanRegistry.Add(human);
        DataStorage.Instance.NumberOfHumans = humanRegistry.Count;
    }

    void KillOldHuman()
    {
        humanRegistry.RemoveAll(human => human.CurrentAge >= human.MaxAge);
        DataStorage.Instance.Workers = humanRegistry.Count(h => h.Adult);
        DataStorage.Instance.NumberOfHumans = humanRegistry.Count;
    }

    void Age()
    {
        foreach (Human human in humanRegistry)
        {
            human.CurrentAge++;
            DataStorage.Instance.AvailableFood--;
            if (DataStorage.Instance.AvailableFood <= 0)
            {
                DataStorage.Instance.AvailableFood = 0;
            }
        }
    }

    void HaveKids()
    {
        float foodRequirement = DataStorage.Instance.NumberOfHumans * 1.2f;
        float housingRequirement = DataStorage.Instance.NumberOfHumans * 1.1f;

        if (DataStorage.Instance.AvailableFood > foodRequirement && 
            DataStorage.Instance.AvailableHousing > housingRequirement)
        {
            int pairs = DataStorage.Instance.Workers / 2;  // workers are adults kind of 
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