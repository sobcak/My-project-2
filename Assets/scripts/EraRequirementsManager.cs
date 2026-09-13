using UnityEngine;
using System.Collections.Generic;

public class EraManager : MonoBehaviour
{
    public EraRequriment nextEraRequriment;
    public Dictionary<int, EraRequriment> EraRequrimentsById = new Dictionary<int, EraRequriment>();

    void Start()
    {
        EraRequrimentsById.Add(1, new Era1());
        EraRequrimentsById.Add(2, new Era2());
        EraRequrimentsById.Add(3, new Era3());

        if (EraRequrimentsById.ContainsKey(DataStorage.Instance.CurrentEra))
        {
            nextEraRequriment = EraRequrimentsById[DataStorage.Instance.CurrentEra];
            transmitSignal.TriggerCommand();
        }
        

        Debug.Log($"[BEFORE TEST] Current Era: {DataStorage.Instance.CurrentEra}");
        OnTriggerEnter2D(null);
        Debug.Log($"[AFTER TEST] Current Era: {DataStorage.Instance.CurrentEra}");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (DataStorage.Instance == null)
        {
            Debug.LogError("DataStorage.Instance is null fuck my life");
            return;
        }

        if (nextEraRequriment != null && nextEraRequriment.ValidateNextEraRequirement(EraRequrimentsById, out EraRequriment nextEra))
        {
            Debug.Log($"Advanced to Era: {DataStorage.Instance.CurrentEra}");   
            nextEraRequriment = nextEra;
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
    
    public bool WellNeeded { get; protected set; }
    public bool ChappleNeeded { get; protected set; }
    public bool SchoolNeeded { get; protected set; }

    public virtual bool ValidateNextEraRequirement(Dictionary<int, EraRequriment> requirements, out EraRequriment nextEra)
    {
        nextEra = null;

        bool resourcesMet = DataStorage.Instance.Furniture >= FurnitureNeeded &&
                             DataStorage.Instance.NumberOfHumans >= HumanNeeded &&
                             DataStorage.Instance.Tools >= ToolsNeeded &&
                             DataStorage.Instance.AvailableFood >= FoodNeeded;

        bool buildingsMet = (!WellNeeded || DataStorage.Instance.Well) &&
                            (!ChappleNeeded || DataStorage.Instance.Chapple) &&
                            (!SchoolNeeded || DataStorage.Instance.School);

        if (resourcesMet && buildingsMet)
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
        WellNeeded = true;
    }
}

public class Era2 : EraRequriment
{
    public Era2()
    {
        EraId = 2;
        FurnitureNeeded = 20;
        ToolsNeeded = 30;
        HumanNeeded = 50;
        ChappleNeeded = true;
    }
}

public class Era3 : EraRequriment
{
    public Era3()
    {
        EraId = 3;
        FurnitureNeeded = 40;
        ToolsNeeded = 45;
        HumanNeeded = 70;
        SchoolNeeded = true;
    }
}