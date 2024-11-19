using UnityEngine;

public class SignalTest : MonoBehaviour
{

    [SerializeField] int i = 0;

    public void Click()
    {
        i++;
    }
}
