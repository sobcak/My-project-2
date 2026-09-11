using UnityEngine;

public class HumanScript : MonoBehaviour
{
    public static int ageRangeLow = -30;
    public static int ageRangeHigh = 25;
    public const int baseAge = 40;
    
    public int MaxAge;
    public int CurrentAge = 0;

    void Age()
    {
        CurrentAge++;
        if (CurrentAge >= MaxAge)
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        MaxAge = baseAge + Random.Range(ageRangeLow, ageRangeHigh);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
