using UnityEngine;
using System.Collections.Generic;

public class BuildingManager:MonoBehaviour
{
    public static List<Building> buildings = new List<Building>();
    
    
    public DataStorage dataAsset;


    void Start()
    {
        if (dataAsset == null)
        {
            dataAsset = new DataStorage();
        }
        transform.position = new Vector2(5000,5000);
    }
    

    Building CreateBuilding(BuildingType type)
    {
        switch (type)
        {
            default:
                return null; 
                break;
            case BuildingType.Farm:
                return BuildingFactory.Farm with { };
            break;
            case BuildingType.Mine:
                return BuildingFactory.Mine with { };
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SortByPriority();
        int currentFocus = 0;
        Building focusedBuilding = null;
        for (int i = 0; i < dataAsset.NumberOfHumans; i++)
        {
            if(buildings.Count -1> currentFocus)
                focusedBuilding = buildings[i];
            else
            {
                break;
            }
    
            focusedBuilding.CurrentWorkforce++;
            if (focusedBuilding.CurrentWorkforce == focusedBuilding.DesiredWorkforce)
            {
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
