using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class HumanManagerScript : MonoBehaviour
{
    public List<Human> humanRegistry = new List<Human>();

    public DataStorage dataAsset;
    
    
    void CreateHuman()
    {
        Human human = new Human();
        humanRegistry.Add(human);
        dataAsset.NumberOfHumans = humanRegistry.Count;
    }
    
    void KillOldHuman()
    {
        foreach (Human human in humanRegistry)
        {
            if (human.CurrentAge == human.MaxAge)
            {
                humanRegistry.Remove(human);
            }
        }
        dataAsset.NumberOfHumans = humanRegistry.Count;
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
        if (dataAsset.AvailableFood > dataAsset.NumberOfHumans + dataAsset.NumberOfHumans * 0.2) // If we have food to spare
        {
            if (dataAsset.AvailableHousing > dataAsset.NumberOfHumans + dataAsset.NumberOfHumans * 0.1)
            {
                for (int i = 0; i < dataAsset.NumberOfHumans / 2; i++)
                {
                    int kid = Random.Range(0, 9);
                    if (kid == 8) // Kid is born
                    {
                        CreateHuman();
                    }
                    
                }
            }
        } 
    }

    
    
    
    
    
    
}
