using UnityEngine;
using UnityEngine.SceneManagement;
public class retuntomenuniga : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
