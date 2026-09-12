using System;
using UnityEngine;
using System.Collections.Generic;

public class BuildingManager : MonoBehaviour
{
    public static List<Building> buildings = new List<Building>();

    void Start()
    {
        transform.position = new Vector2(5000, 5000);
        Debuging();
    }

    void Debuging()
    {
        Debug.Log("Debugging Building manager");
        RegisterBuilding(CreateBuilding(BuildingType.Farm));
    }

    public void GetToWork()
    {
        Building focusedBuilding = null;

        foreach (Building b in buildings)
        {
            // Check required material
            int requiredWood = b.MaterialToRun.Wood;
            int requiredStone = b.MaterialToRun.Stone;
            int requiredBrick = b.MaterialToRun.Bricks;

            // Use >= to allow running when resources exactly match requirements
            if (DataStorage.Instance.Wood >= requiredWood && 
                DataStorage.Instance.Stone >= requiredStone && 
                DataStorage.Instance.brick >= requiredBrick)
            {
                // Subtract required resources
                DataStorage.Instance.Wood -= requiredWood;
                DataStorage.Instance.Stone -= requiredStone;
                DataStorage.Instance.brick -= requiredBrick;

                int woodToAdd = b.MaterialProduction.Wood * b.CurrentWorkforce;
                int stoneToAdd = b.MaterialProduction.Stone * b.CurrentWorkforce;
                int bricksToAdd = b.MaterialProduction.Bricks * b.CurrentWorkforce;
                int foodToAdd = b.MaterialProduction.Food * b.CurrentWorkforce;
                
                DataStorage.Instance.Wood += woodToAdd;
                DataStorage.Instance.Stone += stoneToAdd;
                DataStorage.Instance.brick += bricksToAdd;
                DataStorage.Instance.AvailableFood += foodToAdd;
                
                Debug.Log($"New amount of Wood {DataStorage.Instance.Wood} New amount of Stone {DataStorage.Instance.Stone} New Amount of Food {DataStorage.Instance.AvailableFood}");
            }
        }
    }
    
    
    // fuck 

    static bool TryToBuild(Building b)
    {
        if (DataStorage.Instance.Wood >= b.MaterialCost.Wood && DataStorage.Instance.Stone >= b.MaterialCost.Stone &&
            DataStorage.Instance.brick >= b.MaterialCost.Bricks)
        {
            DataStorage.Instance.Wood -= b.MaterialCost.Wood;
            DataStorage.Instance.Stone -= b.MaterialCost.Stone;
            DataStorage.Instance.brick -= b.MaterialCost.Bricks;
            return true;
        }
        return false;
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    public static Building CreateBuilding(BuildingType type)
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
            // Fixed off-by-one check to safely access list elements
            if (currentFocus < buildings.Count)
            {
                focusedBuilding = buildings[currentFocus];
            }
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
            
            GetToWork(); // Get Produced goods
        }
        
        // reset
        currentFocus = 0;
    }

    void SortByPriority()
    {
        buildings.Sort((a, b) => a.Priority.CompareTo(b.Priority));
    }
    
    public static void RegisterBuilding(Building b)
    {
        if (b != null)
            if(TryToBuild(b))
                buildings.Add(b);
            else
            {
                Debug.Log("Not enough materials");
            }
    }
    
    void UnregisterBuilding(Building b)
    {
        if (b != null && buildings.Contains(b))
        {
            buildings.Remove(b);
        }
    }
}