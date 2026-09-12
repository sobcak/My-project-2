using UnityEngine;

[CreateAssetMenu(fileName = "DataStorage", menuName = "Scriptable Objects/DataStorage")]
public class DataStorage : ScriptableObject
{
    public int NumberOfHumans;
    public int AvailableFood = 100;
    public int AvailableHousing = 100;
    public int Workers;
    
    public int Stone;
    public int Wood;
    public int brick;

   
}
