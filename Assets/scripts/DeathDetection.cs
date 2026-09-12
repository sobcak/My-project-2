using UnityEngine;

public class DeathDetection : MonoBehaviour
{
    bool candie = false;
    [SerializeField] public GameObject ballus;

    private void Awake()
    {
        Invoke("set", 20);
    }
    private void Update()
    {
        if (candie)
        {
            if(DataStorage.Instance.NumberOfHumans == 0)
            {
                ballus.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
   void set()
    {
        candie = true;
    }

}
