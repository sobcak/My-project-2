using System;
using Random = UnityEngine.Random;

[System.Serializable]
public class Human
{
    public int MaxAge; 
    public int CurrentAge;
    public bool Employed;
    public bool Adult => CurrentAge >= 10;
    public bool Homeless;
    
    public Human()
    {
        int MinOfset = -30;
        int MaxOfset = 20;
        
        MaxAge = 40 + Random.Range(MinOfset, MaxOfset);
        CurrentAge = 0;
        Homeless = false;
    }
    
    
}
