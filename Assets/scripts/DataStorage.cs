using UnityEngine;

[CreateAssetMenu(fileName = "DataStorage", menuName = "Scriptable Objects/DataStorage")]
public class DataStorage : ScriptableObject
{
    
    
    // Global static reference
    public static DataStorage Instance { get; private set; }

    public int NumberOfHumans;
    public int AvailableFood = 100;
    public int AvailableHousing = 100;
    public int Workers;
    
    public int Stone;
    public int Wood;
    public int brick;

    
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