using UnityEngine;
using System.Collections.Generic;

using UnityEngine;
using System.Collections.Generic;

public class EraManager : MonoBehaviour
{
    public EraRequriment nextEraRequriment;
    public Dictionary<int, EraRequriment> EraRequrimentsById = new Dictionary<int, EraRequriment>();

    void Start()
    {
        // Populate all era requirements
        EraRequrimentsById.Add(1, new Era1());
        EraRequrimentsById.Add(2, new Era2());
        EraRequrimentsById.Add(3, new Era3());

        if (EraRequrimentsById.ContainsKey(DataStorage.Instance.CurrentEra))
        {
            nextEraRequriment = EraRequrimentsById[DataStorage.Instance.CurrentEra];
        }

        DataStorage.Instance.Furniture = 10;
        DataStorage.Instance.NumberOfHumans = 30;

        Debug.Log($"[BEFORE TEST] Current Era: {DataStorage.Instance.CurrentEra}");

        OnTriggerEnter2D(null);

        Debug.Log($"[AFTER TEST] Current Era: {DataStorage.Instance.CurrentEra}");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Current Era: " + DataStorage.Instance.CurrentEra);
        Debug.Log("OnTrigger era reached");
        if (DataStorage.Instance == null)
        {
            Debug.LogError("DataStorage.Instance is null");
            return;
        }

        if (nextEraRequriment != null && nextEraRequriment.ValidateNextEraRequirement(EraRequrimentsById, out EraRequriment nextEra))
        {
            Debug.Log($"Advanced to Era: {DataStorage.Instance.CurrentEra}");   
            nextEraRequriment = nextEra; // Update
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
    
    public int FoodNeeded { get; protected set; }
    
    public int ToolsNeeded { get; protected set; }

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