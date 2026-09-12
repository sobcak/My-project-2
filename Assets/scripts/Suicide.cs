using UnityEngine;

public class Suicide : MonoBehaviour
{
    [SerializeField] private GameObject Noose;
    public void KickTheChair()
    {
        Noose.SetActive(false);
    }

}
