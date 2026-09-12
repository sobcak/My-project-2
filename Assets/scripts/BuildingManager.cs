using UnityEngine;
using System.Collections.Generic;

public class BuildingManager:MonoBehaviour
{
    public static List<Building> buildings = new List<Building>();
    
    


    void Start()
    {
        transform.position = new Vector2(5000,5000);
        Debuging();
    }

    void Debuging()
    {
        Debug.Log("Debuging Building manger");
        RegisterBuilding(CreateBuilding(BuildingType.Farm));
    }

    Building CreateBuilding(BuildingType type)
    {
        switch (type)
        {
            case BuildingType.Farm:
                Debug.Log("Farm");
                return BuildingFactory.Farm with { };
            case BuildingType.Mine:
                Debug.Log("Mine");
                return BuildingFactory.Mine with { };
            default:
                return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log("OnTriggerEnter2DBuild");
        Debug.Log(DataStorage.Instance.NumberOfHumans + " Building number of humans");
        
        SortByPriority();
        int currentFocus = 0;
        Building focusedBuilding = null;
        for (int i = 0; i < DataStorage.Instance.NumberOfHumans; i++)
        {
            if(buildings.Count -1 > currentFocus)
                focusedBuilding = buildings[currentFocus];           
            else
            {
                Debug.Log("BREAK");
                break;
            }
    
            Debug.Log("AFTER BREAK");
            focusedBuilding.CurrentWorkforce++;
            if (focusedBuilding.CurrentWorkforce >= focusedBuilding.DesiredWorkforce)
            {
                Debug.Log("Desired work full");
                currentFocus++;
            }
        }
        // reset
        currentFocus = 0;
        
    }




    void SortByPriority()
    {
        buildings.Sort((a, b) => a.Priority.CompareTo(b.Priority));
    }
    
    
    
    void RegisterBuilding(Building b)
    {
        if(b != null)
            buildings.Add(b);
    }
    
    void UnregisterBuilding(Building b)
    {
        if (b != null)
            if (buildings.Contains(b))
                buildings.Remove(b);
    }
}
