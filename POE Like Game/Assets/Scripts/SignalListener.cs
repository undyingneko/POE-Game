using UnityEngine;
using System;
using UnityEngine.Events;

[Serializable]
public class SignalEvent : UnityEvent<Component, object>
{ 
    
}

public class SignalListener : MonoBehaviour
{
    public Signal targetSignal;
    public SignalEvent onEventRise;

    private void OnEnable()
    {
        if (targetSignal = null)
        {
            Debug.LogError("Target signal is not assigned! !! ");
            return;
        }

        targetSignal.RegisterListener(this);
    }

    private void OnDisable()
    {
        if (targetSignal == null)
        {

            Debug.LogError("Target signal is not assigned! !! ");
            return;
        }

        targetSignal.UnRegisterListener(this);
    }

    public void OnEventRise(Component sender, object data)
    {
        onEventRise.Invoke(sender, data);
    }




}
