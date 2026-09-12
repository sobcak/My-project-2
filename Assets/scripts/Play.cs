using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
    public Button PlayButton;
    public Button QuitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayButton.onClick.AddListener(TaskOnClick);
        QuitButton.onClick.AddListener(FuckingQuitOnClick);

    }


    void TaskOnClick()
    {
        SceneManager.LoadScene("OliverTest");
        Debug.Log("Tlkacidlo start hje pressed");
    }
    void FuckingQuitOnClick()
    {
        Application.Quit();
        Debug.Log("I am twing to quit :,-)");

    }
}
