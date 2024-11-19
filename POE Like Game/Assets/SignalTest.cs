using UnityEngine;

public class SignalTest : MonoBehaviour
{

    [SerializeField] int i = 0;
    [SerializeField] Signal signal;

    public void Click()
    {
        i++;
        signal.Rise(this, i);
    }
}
