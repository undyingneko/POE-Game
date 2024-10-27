using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractInput : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI textOnScreen;

    [HideInInspector]
    public InteractableObject hoveringOverObject;


    void Update()
    {
        CheckInteractObject();

        if (Input.GetMouseButtonDown(0))
        {
            if (hoveringOverObject != null)
            {

                hoveringOverObject.Interact();
            }
        }
    }

    private void CheckInteractObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            InteractableObject interactableObject = hit.transform.GetComponent<InteractableObject>();
            if (interactableObject != null)
            {
                hoveringOverObject = interactableObject;
                textOnScreen.text = hoveringOverObject.objectName;
            }
            else{
                hoveringOverObject = null;
                textOnScreen.text = "";
            }
        }


    }
}
