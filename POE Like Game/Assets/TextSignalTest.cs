using TMPro;
using UnityEngine;


public class TextSignalTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmp;

    public void ReceiveTextValueAsSignal(Component sender, object value)
    {
        if (value is int)
        {
            int i = (int)value;
            tmp.text = i.ToString();
        }
    }
}
