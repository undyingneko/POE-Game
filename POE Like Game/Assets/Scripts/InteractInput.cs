using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractInput : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI textOnScreen;
    [SerializeField] UIPoolBar hpBar;
    GameObject currentHoverOverObject;

    [HideInInspector]
    public InteractableObject hoveringOverObject;

    [HideInInspector]
    public IDamageable attackTarget;
    
    InteractHandler interactHandler;
    Vector2 mousePosition;

    private void Awake()
    {
        interactHandler = GetComponent<InteractHandler>();
    }
    void Update()
    {
        CheckInteractObject();
    }

    public void MousePositionInput(InputAction.CallbackContext callbackContext)
    {
        mousePosition = callbackContext.ReadValue<Vector2>();
    }

    private void CheckInteractObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (currentHoverOverObject != hit.transform.gameObject)
            {
                currentHoverOverObject = hit.transform.gameObject;
                UpdateInteractableObject(hit);
            }
        }
    }
    
    void UpdateInteractableObject(RaycastHit hit)
    {
        InteractableObject interactableObject = hit.transform.GetComponent<InteractableObject>();
        if (interactableObject != null)
        {
            hoveringOverObject = interactableObject;
            attackTarget = interactableObject.GetComponent<IDamageable>();
            textOnScreen.text = hoveringOverObject.objectName;
        }
        else
        {
            attackTarget = null;
            hoveringOverObject = null;
            textOnScreen.text = "";
        }
        
        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        if (attackTarget != null)
        {
            // hpBar.Show(attackTarget.lifePool);
        }
        else{
            hpBar.Clear();
        }
    }

    internal bool InteractCheck()
    {
        return hoveringOverObject != null;
        
    }

  
}




