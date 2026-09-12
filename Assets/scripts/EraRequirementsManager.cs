using UnityEngine;
using System.Collections.Generic;

public class EraManager : MonoBehaviour
{
    public EraRequriment nextEraRequriment;
    public Dictionary<int, EraRequriment> EraRequrimentsById = new Dictionary<int, EraRequriment>();

    void Start()
    {
        // Populate requirements
        EraRequrimentsById.Add(1, new Era1());
        EraRequrimentsById.Add(2, new Era2());

        if (EraRequrimentsById.ContainsKey(1))
        {
            nextEraRequriment = EraRequrimentsById[1];
        }
        
        transform.position = new Vector2(5025, 5025);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Era Triggered");

        if (DataStorage.Instance == null)
        {
            Debug.LogError("DataStorage.Instance is null! Make sure your ScriptableObject is loaded.");
            return;
        }

        if (nextEraRequriment != null && nextEraRequriment.ValidateNextEraRequirement(EraRequrimentsById, out EraRequriment nextEra))
        {
            Debug.Log($"Advanced to Era: {DataStorage.Instance.CurrentEra}");   
            nextEraRequriment = nextEra; // Updated to next requirement (or null if max era reached)
        }
        else
        {
            Debug.Log("Requirements not met or already at max era.");
        }
    }
}

public abstract class EraRequriment
{
    public int EraId { get; protected set; }
    public int FurnitureNeeded { get; protected set; }
    public int HumanNeeded { get; protected set; }

    public virtual bool ValidateNextEraRequirement(Dictionary<int, EraRequriment> requirements, out EraRequriment nextEra)
    {
        nextEra = null;
        Debug.Log("era"+ DataStorage.Instance.CurrentEra + "Furniture" + DataStorage.Instance.Furniture + "Human" + DataStorage.Instance.NumberOfHumans);

        if (DataStorage.Instance.Furniture >= FurnitureNeeded && DataStorage.Instance.NumberOfHumans >= HumanNeeded)
        {
            DataStorage.Instance.CurrentEra = EraId + 1;
            
            requirements.TryGetValue(EraId + 1, out nextEra);
            return true;
        }

        return false;
    }
}

public class Era1 : EraRequriment
{
    public Era1()
    {
        EraId = 1;
        FurnitureNeeded = 10;
        HumanNeeded = 30;
    }
}

public class Era2 : EraRequriment
{
    public Era2()
    {
        EraId = 2;
        FurnitureNeeded = 20;
        HumanNeeded = 50;
    }
}

public class Era3 : EraRequriment
{
    public Era3()
    {
        EraId = 3;
        FurnitureNeeded = 20;
        HumanNeeded = 60;
    }
}