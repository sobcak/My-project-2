using UnityEngine;
using System.Collections.Generic;

public class BuildingManager:MonoBehaviour
{
    public static List<Building> buildings = new List<Building>();

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
