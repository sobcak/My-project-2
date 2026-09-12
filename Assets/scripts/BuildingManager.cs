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

    int CalculateWorkMultiplier(int Multiplier)
    {
        double final = Multiplier * 0.6;
        if (final < 1)
        {
            final = 1;
        }
        return (int)final;
    }

    public void GetToWork()
    {
        Building focusedBuilding = null;
        
        int BonusScaling = CalculateWorkMultiplier(DataStorage.Instance.CurrentEra);

        foreach (Building b in buildings)
        {
            // required material
            int requiredWood = b.MaterialToRun.Wood;
            int requiredStone = b.MaterialToRun.Stone;
            int requiredBrick = b.MaterialToRun.Bricks;

            // Running
            if (DataStorage.Instance.Wood >= requiredWood && 
                DataStorage.Instance.Stone >= requiredStone && 
                DataStorage.Instance.brick >= requiredBrick)
            {
                // Subtract required resources
                DataStorage.Instance.Wood -= requiredWood;
                DataStorage.Instance.Stone -= requiredStone;
                DataStorage.Instance.brick -= requiredBrick;

                // Calculate final resources
                int woodToAdd = b.MaterialProduction.Wood * b.CurrentWorkforce * BonusScaling;
                int stoneToAdd = b.MaterialProduction.Stone * b.CurrentWorkforce * BonusScaling;
                int bricksToAdd = b.MaterialProduction.Bricks * b.CurrentWorkforce * BonusScaling;
                int foodToAdd = b.MaterialProduction.Food * b.CurrentWorkforce * BonusScaling;
                
                // Add resources
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
            
            // Add bonus space for storage
            if (b.BuildingType == BuildingType.Storage)
            {
                DataStorage.Instance.MaxResources  = DataStorage.Instance.MaxResources + b.BonusSpace;
            }
            
            
            
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
            case BuildingType.Forestry:
                Debug.Log("Forestry");
                return BuildingFactory.Forestry with { };
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

        for (int i = 0; i < DataStorage.Instance.Workers; i++)
        {
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

    public static bool RegisterBuilding(Building b)
    {
        if (b != null)
        {
            if (TryToBuild(b))
            {
                buildings.Add(b);
                return true;
            }
        }
        return false;
    }



    void UnregisterBuilding(Building b)
    {
        if (b != null && buildings.Contains(b))
        {
            buildings.Remove(b);
        }
    }
}