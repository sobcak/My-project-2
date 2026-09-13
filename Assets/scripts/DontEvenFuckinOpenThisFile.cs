using UnityEngine;
using UnityEngine.SceneManagement;

public class DontEvenFuckinOpenThisFile : MonoBehaviour
{


    int indexm = 0;
    bool giusgbkjsbj = true;
    [SerializeField] private GameObject b;

    private void Update()
    {
        if (Input.GetKeyDown("right"))
        {
            if (giusgbkjsbj)
            {
                Forward();
                giusgbkjsbj = false;
            }
            
        }
        if (Input.GetKeyDown("left"))
        {
            if (giusgbkjsbj)
            {
                Backward();
                giusgbkjsbj = false;
            }
        }
        if (Input.GetKeyUp("right"))
        {
            giusgbkjsbj = true;

        }
        if (Input.GetKeyUp("left"))
        {
            giusgbkjsbj = true;

        }
        if (indexm == 13)
        {
            b.SetActive(true);
        }
        else { b.SetActive(false); }
    }
    public void Forward()
    {
        if(indexm == 13)
        {
            b.SetActive(true);
        }
        else
        {
            indexm = indexm + 1;
            b.SetActive(false);
        }
        
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"sprites/Tutorial Pages/{indexm}");
    }
    public void Backward()
    {
        if (indexm == 1  || indexm == 0)
        {
            b.SetActive(false);
        }
        else
        {
            indexm = indexm - 1;
            b.SetActive(false);
        }

        
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"sprites/Tutorial Pages/{indexm}");
    }
    public void GetMeHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GetPlayinBoy()
    {
        SceneManager.LoadScene("backupProDavida");
    }
}
