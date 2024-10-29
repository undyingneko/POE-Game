using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInput : MonoBehaviour
{
    InteractInput interactInput;
    AttackHandler attackHandler;
    private void Awake()
    {
        interactInput = GetComponent<InteractInput>();
        attackHandler = GetComponent<AttackHandler>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (interactInput.hoveringOverCharacter != null)
            {
                attackHandler.Attack(interactInput.hoveringOverCharacter);
            }
        }
    }
}
