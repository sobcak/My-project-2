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
                int stoneToAdd = b.MaterialProduction.Stone * b.CurrentWorkforce * bonusScaling;
                DataStorage.Instance.Stone += stoneToAdd;
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
            Debug.Log("suck");
            Debug.Log(b);
            Debug.Log(b.BuildingType.ToString());
            if (b.SubType == SubType.Storage)
            {
                Debug.Log("plus");
                DataStorage.Instance.Housing = DataStorage.Instance.Housing + b.BonusHousing;
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
            case BuildingType.Housing:
                return BuildingFactory.CreateHousing();
            case BuildingType.Storage:
                return BuildingFactory.CreateStorage();
            case BuildingType.Well:
                return BuildingFactory.CreateWell();
            case BuildingType.Saw:
                return BuildingFactory.CreateSaw();
            default:
                return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered OnTrigger Building");
        Debug.Log("Current Workers" + DataStorage.Instance.Workers);

        foreach (Building b in buildings)
        {
            b.CurrentWorkforce = 0;
        }

        if (buildings.Count == 0 || DataStorage.Instance.Workers <= 0) return;

        List<Building> priorityOneBuildings = buildings.FindAll(b => b.Priority == 1);
        List<Building> lowerPriorityBuildings = buildings.FindAll(b => b.Priority > 1);

        lowerPriorityBuildings.Sort((a, b) => a.Priority.CompareTo(b.Priority));

        int totalWorkers = DataStorage.Instance.Workers;
        int priorityOnePool = Mathf.RoundToInt(totalWorkers * 0.40f);
        int lowerPriorityPool = totalWorkers - priorityOnePool;

        int unassignedP1 = DistributeWorkersToGroup(priorityOneBuildings, priorityOnePool);

        lowerPriorityPool += unassignedP1;

        int leftoverWorkers = DistributeWorkersToGroup(lowerPriorityBuildings, lowerPriorityPool);

        if (leftoverWorkers > 0)
        {
            DistributeWorkersToGroup(priorityOneBuildings, leftoverWorkers);
        }

        GetToWork();
    }

    int DistributeWorkersToGroup(List<Building> buildingGroup, int availableWorkers)
    {
        int currentBuildingIndex = 0;

        while (availableWorkers > 0 && currentBuildingIndex < buildingGroup.Count)
        {
            Building targetBuilding = buildingGroup[currentBuildingIndex];

            if (targetBuilding.CurrentWorkforce < targetBuilding.DesiredWorkforce)
            {
                targetBuilding.CurrentWorkforce++;
                availableWorkers--;
            }
            else
            {
                currentBuildingIndex++;
            }
        }

        return availableWorkers; // Returns unused workers from this pool
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