using System;
using UnityEngine;

public class LimitManager : MonoBehaviour
{
    private void Update()
    {
        int Limit = DataStorage.Instance.MaxResources;

        if (DataStorage.Instance.AvailableFood > Limit)
        {
            DataStorage.Instance.AvailableFood = Limit;
        }
        if (DataStorage.Instance.Wood > Limit)
        {
            DataStorage.Instance.Wood = Limit;
        }
        if (DataStorage.Instance.Stone> Limit)
        {
            DataStorage.Instance.Stone = Limit;
        }
        if (DataStorage.Instance.brick > Limit)
        {
            DataStorage.Instance.brick= Limit;
        }
        if (DataStorage.Instance.Furniture > Limit)
        {
            DataStorage.Instance.Furniture = Limit;
        }
    }
}
