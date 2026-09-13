using UnityEngine;

public class DontEvenFuckinOpenThisFile : MonoBehaviour
{


    int indexm = 0;
    
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
