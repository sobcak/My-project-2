using UnityEngine;

public class iswon : MonoBehaviour
{
    [SerializeField] private GameObject balls;
    void Update()
    {
        if (DataStorage.Instance.WonGame)
        {
            balls.SetActive(true);
        }
    }
}
