using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractInput : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI textOnScreen;
    [SerializeField] UIPoolBar hpBar;
    GameObject currentHoverOverObject;

    [HideInInspector]
    public InteractableObject hoveringOverObject;
    [HideInInspector]
    public Character hoveringOverCharacter;
    InteractableObject interactedObject;
    [SerializeField] float interactRange = 3.5f;
    CharacterMovement characterMovement;
    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        CheckInteractObject();
        if (interactedObject != null)
        {
            ProcessInteract();
        }
    }

    private void CheckInteractObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
            hoveringOverCharacter = interactableObject.GetComponent<Character>();
            textOnScreen.text = hoveringOverObject.objectName;
        }
        else
        {
            hoveringOverCharacter = null;
            hoveringOverObject = null;
            textOnScreen.text = "";
        }
        
        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        if (hoveringOverCharacter != null)
        {
            hpBar.Show(hoveringOverCharacter.lifePool);
        }
        else{
            hpBar.Clear();
        }
    }

    internal void Interact()
    {
        interactedObject = hoveringOverObject;
    }
    void ProcessInteract()
    {
        float distance = Vector3.Distance(transform.position, interactedObject.transform.position);

        if (distance < interactRange)
        {
            interactedObject.Interact();
            characterMovement.Stop();

            interactedObject = null;
        }
        else {
            characterMovement.SetDestination(interactedObject.transform.position);
        }
    }

    internal bool InteractCheck()
    {
        return hoveringOverObject != null;
        
    }
}




