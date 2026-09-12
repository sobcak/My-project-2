using UnityEngine;

[CreateAssetMenu(fileName = "DataStorage", menuName = "Scriptable Objects/DataStorage")]
public class DataStorage : ScriptableObject
{
    
    
    // Global static reference
    public static DataStorage Instance { get; private set; }

    public int NumberOfHumans;
    public int AvailableFood = 0;
    public int AvailableHousing = 100;
    public int Workers;

    public int Stone = 100;
    public int Wood = 100;
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