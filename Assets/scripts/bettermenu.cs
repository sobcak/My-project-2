using UnityEngine;
using UnityEngine.SceneManagement;

public class bettermenu : MonoBehaviour
{
    [SerializeField] string JmenoSceny;
    [SerializeField] private GameObject sklo;

    // teleports to scene in JmenoSceny
    public void YouShallMove()
    {
        SceneManager.LoadScene(JmenoSceny);
        Debug.Log($"Teleporting to {JmenoSceny}");
        
    }
    // show/hide
    public void YouShallMaybeSee()
    {
        if(sklo == null) return;
        {
            sklo.SetActive(!sklo.activeSelf);
        }
        
    }
    public void Leavuju()
    {
        Debug.Log("Quituju tentokrát fr");
        Application.Quit();
        
    }
}
