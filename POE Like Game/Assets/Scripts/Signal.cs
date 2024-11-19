using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Game Signal")]
public class Signal : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>();

    public void Rise(Component sender, object data)
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRise(sender, data);
        }
    }


    public void RegisterListener(SignalListener signalListener)
    {
        if (listeners == null) { listeners = new List<SignalListener>(); }
        if (listeners.Contains(signalListener) == false)
        {
            listeners.Add(signalListener);
        }
    }

    public void UnRegisterListener(SignalListener signalListener)
    {
        if (listeners == null) { listeners = new List<SignalListener>(); }
        if (listeners.Contains(signalListener) == true)
        {
            listeners.Remove(signalListener);
        }

            
    }
}
