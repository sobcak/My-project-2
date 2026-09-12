using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class BuildingManager : MonoBehaviour
{
    public static List<Building> buildings = new List<Building>();

    void Start()
    {
        transform.position = new Vector2(5000, 5000);
        //Debuging();
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
        int bonusScaling = CalculateWorkMultiplier(DataStorage.Instance.CurrentEra);
        Debug.Log($"Got To Work");
        
        foreach (Building b in buildings)
        {
            Debug.Log("Testy");
            if (b.CurrentWorkforce <= 0) continue; // Skip buildings without workers

            int requiredWood = b.MaterialToRun.Wood;
            int requiredStone = b.MaterialToRun.Stone;
            int requiredBrick = b.MaterialToRun.Bricks;

            // Check if there are enough resources to run production
            if (DataStorage.Instance.Wood >= requiredWood && 
                DataStorage.Instance.Stone >= requiredStone && 
                DataStorage.Instance.brick >= requiredBrick)
            {
                // Deduct inputs
                DataStorage.Instance.Wood -= requiredWood;
                DataStorage.Instance.Stone -= requiredStone;
                DataStorage.Instance.brick -= requiredBrick;

                // Add production output scaled by workforce and era
                
                Debug.Log(DataStorage.Instance.Wood);

                int woodToAdd = b.MaterialProduction.Wood * b.CurrentWorkforce * bonusScaling;
                DataStorage.Instance.Wood += woodToAdd;
                Debug.Log("Wood to Add " +  woodToAdd);
                DataStorage.Instance.Stone += b.MaterialProduction.Stone * b.CurrentWorkforce * bonusScaling;
                DataStorage.Instance.brick += b.MaterialProduction.Bricks * b.CurrentWorkforce * bonusScaling;
                DataStorage.Instance.AvailableFood += b.MaterialProduction.Food * b.CurrentWorkforce * bonusScaling;
                
                Debug.Log(DataStorage.Instance.Wood + " wood after");

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
                DataStorage.Instance.AvailableHousing = DataStorage.Instance.AvailableHousing + b.BonusHousing;
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
                return BuildingFactory.CreateFarm();
            case BuildingType.Mine:
                return BuildingFactory.CreateMine();
            case BuildingType.Forestry:
                return BuildingFactory.CreateForestry();
            default:
                return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered OnTrigger Building" );
        Debug.Log("Current Workers" + DataStorage.Instance.Workers);
        SortByPriority();

        foreach (Building b in buildings)
        {
            b.CurrentWorkforce = 0;
        }

        int currentFocus = 0;

        for (int i = 0; i < DataStorage.Instance.Workers; i++)
        {
            if (currentFocus >= buildings.Count) break;

            Building focusedBuilding = buildings[currentFocus];
            focusedBuilding.CurrentWorkforce++;

            if (focusedBuilding.CurrentWorkforce >= focusedBuilding.DesiredWorkforce)
            {
                currentFocus++;
            }
        }

        GetToWork();
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