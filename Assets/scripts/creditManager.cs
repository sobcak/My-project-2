using UnityEngine;
using UnityEngine.SceneManagement;

public class creditManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Update()
    {

        if(Input.anyKey)
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}
