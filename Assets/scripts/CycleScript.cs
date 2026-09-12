using System;
using UnityEngine;

public class CycleScript : MonoBehaviour
{

    Vector2 GetAJobtrigger = new Vector2(5000, 5000);
    Vector2 Eattrigger = new Vector2(5005, 5005);
    Vector2 Worktrigger = new Vector2(5010, 5010);
    Vector2 Dietrigger = new Vector2(5015, 5015);
    Vector2 Kidstrigger = new Vector2(5020, 5020);
    Vector2 Updatetrigger = new Vector2(5025, 5025);

    
    [SerializeField] private GameObject triggerBox;
    int timer = 0;
    private GameObject temp;


    void FixedUpdate() // Fuck fixed update
    {
        timer++;
        // reset the shit out of the timer
        if (timer == 500)
        {
            timer = 0;
        }

        if (timer == 50)
        {
            GameObject temp = Instantiate(triggerBox, GetAJobtrigger, Quaternion.identity);
        }

        if (timer == 55)
        {
            DestroyImmediate(temp, true);
        }

        if (timer == 100)
        {
            GameObject temp = Instantiate(triggerBox, Eattrigger, Quaternion.identity);
        }
        if (timer == 105)
        {
            DestroyImmediate(temp, true);
        }

        if (timer == 150)
        {
            GameObject temp = Instantiate(triggerBox, Worktrigger, Quaternion.identity);
        }

        if (timer == 155)
        {
            DestroyImmediate(temp, true);

        }
        
        if (timer == 350)
        {
            GameObject temp = Instantiate(triggerBox, Dietrigger, Quaternion.identity);
        }

        if (timer == 355)
        {
            DestroyImmediate(temp, true);
        }
        
        if (timer == 400)
        {
            GameObject temp = Instantiate(triggerBox, Kidstrigger, Quaternion.identity);
        }

        if (timer == 405)
        {
            DestroyImmediate(temp, true);
        }

        if (timer == 450)
        {
            GameObject temp = Instantiate(triggerBox, Updatetrigger, Quaternion.identity);
        }
        if(timer == 455)
        {
            DestroyImmediate(temp, true);
        }
    }
    
}


