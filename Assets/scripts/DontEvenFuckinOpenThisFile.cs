using UnityEngine;

public class DontEvenFuckinOpenThisFile : MonoBehaviour
{


    int indexm = 0;
    bool giusgbkjsbj = true;


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
    }
    public void Forward()
    {
        indexm = indexm + 1;
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"sprites/Tutorial Pages/{indexm}");
    }
    public void Backward()
    {
        indexm = indexm - 1;
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"sprites/Tutorial Pages/{indexm}");
    }
}
