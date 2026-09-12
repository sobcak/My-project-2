using System;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class Human
{
    public int MaxAge; 
    public int CurrentAge;
    public bool Employed;
    public bool Adult => CurrentAge >= 8;
    public bool Homeless;
    
    public Human()
    {
        CurrentAge = 0;
        Homeless = false;
    }
    public void Initialize()
    {
        int minOffset = -30;
        int maxOffset = 20;
        MaxAge = 40 + UnityEngine.Random.Range(minOffset, maxOffset);
    }
}
