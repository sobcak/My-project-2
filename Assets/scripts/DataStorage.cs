using UnityEngine;

[CreateAssetMenu(fileName = "DataStorage", menuName = "Scriptable Objects/DataStorage")]
public class DataStorage : ScriptableObject
{
    public int MaxResources { get; set; } = 50;
    
    
    /// <summary>
    /// Important
    public int CurrentEra = 1;

    /// </summary>


    // Constructed important buildings
    public bool Chapple = true;
    public bool School;

    // Global static reference
    public static DataStorage Instance { get; private set; }

    public int NumberOfHumans = 0;
    public int AvailableFood = 50;
    public int AvailableHousing => Housing - NumberOfHumans;
    public int Housing = 0;
    public int Workers;

    public int Stone = 50;
    public int Wood = 50;
    public int brick;

    // Luxury
    public int Furniture = 0;
    public int Tools = 0;
    
    
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