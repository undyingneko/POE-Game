using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCharacterInput : MonoBehaviour
{
    [SerializeField] MouseInput mouseInput;

    CharacterMovementInput characterMovementInput;
    AttackInput attackInput;
    InteractInput interactInput;

    private void Awake()
    {
        characterMovementInput = GetComponent<CharacterMovementInput>();
        attackInput = GetComponent<AttackInput>();
        interactInput = GetComponent<InteractInput>();
    }
    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) {return; }

        if (Input.GetMouseButton(0))
        {
            if (attackInput.AttackCheck())
            {
                // Debug.Log("attack");
                attackInput.Attack();
                return;
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (interactInput.InteractCheck())
                {
                    // Debug.Log("interact");
                    interactInput.Interact();
                    return;
                }
            }
            if (interactInput.InteractCheck())
            {
                return;
            }

            // Debug.Log("Move");
            interactInput.ResetState();
            characterMovementInput.MoveInput();
        }
    }







}
