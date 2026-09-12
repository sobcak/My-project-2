using UnityEngine;

[CreateAssetMenu(fileName = "DataStorage", menuName = "Scriptable Objects/DataStorage")]
public class DataStorage : ScriptableObject
{
    public int NumberOfHumans;
    public int AvailableFood;
    public int AvailableHousing;
    public int Workers;
    
    public int Stone;
    public int Wood;
    public int brick;
}
