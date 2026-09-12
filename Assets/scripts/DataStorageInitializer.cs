using UnityEngine;

public class DataStorageInitializer : MonoBehaviour
{
   [SerializeField] DataStorage storage;

   void Awake()
   {
      if (storage == null)
      {
         storage = new DataStorage();
      }
   }
}
