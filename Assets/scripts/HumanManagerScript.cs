using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class HumanManagerScript : MonoBehaviour
{
    public List<Human> humanRegistry = new List<Human>();
    List<int> KillHelper =  new List<int>();

    public DataStorage dataAsset;
    

    void Start()
    {
        if (dataAsset == null)
        {
            dataAsset = new DataStorage();
        }
        
        transform.position =  new Vector2(5015,5015);
        // Test create
        CreateHuman();
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
        //Debug.Log("Person was born");
        Human human = new Human();
        humanRegistry.Add(human);
        dataAsset.NumberOfHumans = humanRegistry.Count;
    }
    
    void KillOldHuman()
    {
        //Debug.Log("Kill Reached");
        foreach (Human human in humanRegistry)
        {
            if (human.CurrentAge == human.MaxAge)
            {
                
                KillHelper.Add(humanRegistry.IndexOf(human));  // que their index 
                //Debug.Log("Person died");
            }
        }

        if (KillHelper.Count > 0)
        {
            foreach (int i in KillHelper)
            {
                humanRegistry.RemoveAt(i);
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
        Debug.Log("Kids Reached");
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
