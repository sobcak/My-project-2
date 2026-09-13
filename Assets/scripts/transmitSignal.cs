using System;
using UnityEngine;

public class transmitSignal : MonoBehaviour
{
    public static event Action OnCommandExecuted;

    public static void TriggerCommand()
    {
        //fire the event if any listeners are subscribed
        OnCommandExecuted?.Invoke();
    }
}
