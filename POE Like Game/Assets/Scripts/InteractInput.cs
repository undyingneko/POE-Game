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


    void Update()
    {
        CheckInteractObject();
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
        hoveringOverObject.Interact();
    }

    internal bool InteractCheck()
    {
        return hoveringOverObject != null;
        
    }
}




