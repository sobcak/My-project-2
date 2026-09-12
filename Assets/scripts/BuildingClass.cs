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

}

public class BuildingFactory
{
    public static Building Farm = new Building
    {
        BuildingType = BuildingType.Farm,
        SubType = SubType.Production,
        MaterialCost = (Wood: 10, Stone: 10, Bricks: 0),
        MaterialToRun = (Wood: 0, Stone: 0, Bricks: 0),
        MaterialProduction = (Wood: 0, Stone: 0, Bricks: 0, Food: 10),
        DesiredWorkforce = 5,
        CurrentWorkforce = 0,
        Priority = 1,
    };

    public static Building Mine = new Building()
    {
        BuildingType = BuildingType.Mine,
        SubType = SubType.Production,
        MaterialCost = (Wood: 10, Stone: 10, Bricks: 0),
        MaterialToRun = (Wood: 0, Stone: 0, Bricks: 0),
        DesiredWorkforce = 5,
        CurrentWorkforce = 0,
        Priority = 2,
    };
    
}



