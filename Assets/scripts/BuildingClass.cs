using System.Collections.Generic;
using UnityEngine;

public record Building
{
    public BuildingType BuildingType { get; set; }
    public SubType SubType { get; set; }
    public (int Wood, int Stone, int Bricks) MaterialCost { get; set; } = (0, 0, 0);
    
    // Required to run
    public (int Wood, int Stone, int Bricks) MaterialToRun { get; set; } = (0, 0, 0);
    
    // Produces
    public (int Wood, int Stone, int Bricks, int Food) MaterialProduction { get; set; } = (0, 0, 0, 0);
    
    // Workers
    public int DesiredWorkforce { get; set; } = 0;
    
    public int CurrentWorkforce { get; set; } = 0;
    
    // Priority 
    public int Priority { get; set; } = 0;
    
    public int BonusSpace { get; set; } = 0;

    public int BonusHousing {get; set; } = 0;

}

public static class BuildingFactory
{
    public static Building CreateFarm() => new Building
    {
        BuildingType = BuildingType.Farm,
        SubType = SubType.Production,
        MaterialCost = (Wood: 10, Stone: 5, Bricks: 0),
        MaterialToRun = (Wood: 0, Stone: 0, Bricks: 0),
        MaterialProduction = (Wood: 0, Stone: 0, Bricks: 0, Food: 2),
        DesiredWorkforce = 5,
        CurrentWorkforce = 0,
        Priority = 1,
        BonusSpace = 0,
        BonusHousing = 0
    };

    public static Building CreateForestry() => new Building
    {
        BuildingType = BuildingType.Forestry,
        SubType = SubType.Production,
        MaterialCost = (Wood: 5, Stone: 5, Bricks: 0),
        MaterialToRun = (Wood: 0, Stone: 0, Bricks: 0),
        MaterialProduction = (Wood: 3, Stone: 0, Bricks: 0, Food: 0),
        DesiredWorkforce = 5,
        CurrentWorkforce = 0,
        Priority = 2,
        BonusSpace = 0,
        BonusHousing = 0
    };

    public static Building CreateMine() => new Building
    {
        BuildingType = BuildingType.Mine,
        SubType = SubType.Production,
        MaterialCost = (Wood: 10, Stone: 0, Bricks: 0),
        MaterialToRun = (Wood: 0, Stone: 0, Bricks: 0),
        MaterialProduction = (Wood: 0, Stone: 3, Bricks: 0, Food: 0),
        DesiredWorkforce = 5,
        CurrentWorkforce = 0,
        Priority = 2,
        BonusSpace = 0,
        BonusHousing = 0
    };

    public static Building CreateHousing() => new Building
    {
        BuildingType = BuildingType.Housing,
        SubType = SubType.Storage,
        MaterialCost = (Wood: 10, Stone: 5, Bricks: 0),
        MaterialToRun = (Wood: 0, Stone: 0, Bricks: 0),
        MaterialProduction = (Wood: 0, Stone: 0, Bricks: 0, Food: 0),
        DesiredWorkforce = 0,
        CurrentWorkforce = 0,
        Priority = 10,
        BonusSpace = 0,
        BonusHousing = 3 + (1 * DataStorage.Instance.CurrentEra) // auto scaling housing
    };

    public static Building CreateStorage() => new Building
    {
        BuildingType = BuildingType.Storage,
        SubType = SubType.Storage,
        MaterialCost = (Wood: 10, Stone: 0, Bricks: 0),
        MaterialToRun = (Wood: 0, Stone: 0, Bricks: 0),
        MaterialProduction = (Wood: 0, Stone: 0, Bricks: 0, Food: 0),
        DesiredWorkforce = 0,
        CurrentWorkforce = 0,
        Priority = 10,
        BonusHousing = 0,
        BonusSpace = 3 + (2 * DataStorage.Instance.CurrentEra) // scaling 
    };
}



