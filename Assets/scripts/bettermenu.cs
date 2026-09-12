using UnityEngine;
using UnityEngine.SceneManagement;

public class bettermenu : MonoBehaviour
{
    [SerializeField] string JmenoSceny;

    public void YouShallMove()
    {
        SceneManager.LoadScene(JmenoSceny);
        Debug.Log($"Teleporting to {JmenoSceny}");
        
    }}
