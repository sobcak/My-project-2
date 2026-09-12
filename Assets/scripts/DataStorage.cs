using UnityEngine;

[CreateAssetMenu(fileName = "DataStorage", menuName = "Scriptable Objects/DataStorage")]
public class DataStorage : ScriptableObject
{
    public int MaxResources { get; set; } = 40;
    
    
    /// <summary>
    /// Important
    public int CurrentEra = 1;

    /// </summary>


    // Constructed important buildings
    public bool Chapple = true;
    public bool School;
    
    // Global static reference
    public static DataStorage Instance { get; private set; }

    public int NumberOfHumans = 80;
    public int AvailableFood = 200;
    public int AvailableHousing = 100;
    public int Workers;

    public int Stone = 100;
    public int Wood = 100;
    public int brick;

    // Luxury
    public int Furniture = 50;
    
    public static void Initialize(DataStorage asset)
    {
        Instance = asset;
    }
    
    private void OnEnable()
    {
        // Sets the static reference whenever the asset is loaded
        Instance = this;
    }
}