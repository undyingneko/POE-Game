using System;
using System.Collections;
using System.Collections.Generic;
using CharacterCommand;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerCharacterInput : MonoBehaviour
{
    [SerializeField] MouseInput mouseInput;
    CommandHandler commandHandler;
    CharacterMovementInput characterMovementInput;
    AttackInput attackInput;
    InteractInput interactInput;
    bool isOverUIElement;
    private void Awake()
    {
        commandHandler = GetComponent<CommandHandler>();
        characterMovementInput = GetComponent<CharacterMovementInput>();
        attackInput = GetComponent<AttackInput>();
        interactInput = GetComponent<InteractInput>();
    }
    private void Update()
    {
        isOverUIElement = EventSystem.current.IsPointerOverGameObject();
    }
    
    public void LMB_InputHandle(InputAction.CallbackContext callbackContext)
    {
        if (isOverUIElement == true) { return; }
        
        if (callbackContext.performed || callbackContext.canceled) { return; }

        if (attackInput.AttackCheck())
        {
            AttackCommand(interactInput.hoveringOverObject.gameObject);
            return;
        }
        if (interactInput.InteractCheck())
        {
            InteractCommand(interactInput.hoveringOverObject.gameObject);
            return;
        }
        
        MoveCommand(mouseInput.rayToWorldIntersectionPoint);
    }

    private void MoveCommand(Vector3 point)
    {
        commandHandler.SetCommand(new Command(CommandType.Move, point));
    }

    private void InteractCommand(GameObject target)
    {
        commandHandler.SetCommand(new Command(CommandType.Interact, target));
    }

    private void AttackCommand(GameObject target)
    {
        commandHandler.SetCommand(new Command(CommandType.Attack, target));
    }
}
