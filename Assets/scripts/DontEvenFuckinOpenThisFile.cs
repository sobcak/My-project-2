using UnityEngine;

public class DontEvenFuckinOpenThisFile : MonoBehaviour
{


    int indexm = 0;



    private void Update()
    {
        if (Input.GetKey("left"))
        {
            Forward();
        }
        if (Input.GetKey("right"))
        {
            Forward();
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
