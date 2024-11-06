using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSystemTest : MonoBehaviour
{
    [SerializeField] ItemDropList dropList;


    private void Update()
    {
        if (dropList == null) { return; }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log(dropList.GetDropName());
        }

    }


}
