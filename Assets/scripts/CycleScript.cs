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
            Instantiate(triggerBox, GetAJobtrigger, Quaternion.identity);
            Destroy(triggerBox);
        }

        if (timer == 100)
        {
            Instantiate(triggerBox, Eattrigger, Quaternion.identity);
            Destroy(triggerBox);

        }

        if (timer == 150)
        {
            Instantiate(triggerBox, Worktrigger, Quaternion.identity);
            Destroy(triggerBox);

        }
        if (timer == 350)
        {
            Instantiate(triggerBox, Dietrigger, Quaternion.identity);
            Destroy(triggerBox);

        }
        if (timer == 400)
        {
            Instantiate(triggerBox, Kidstrigger, Quaternion.identity);
            Destroy(triggerBox);

        }

        if (timer == 450)
        {
            Instantiate(triggerBox, Updatetrigger, Quaternion.identity);
            Destroy(triggerBox);

        }
        
    }
    
}


