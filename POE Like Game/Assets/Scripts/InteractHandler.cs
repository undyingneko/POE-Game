using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractHandler : MonoBehaviour
{
    [SerializeField] float interactRange = 3.5f;
    public InteractableObject interactedObject;
    CharacterMovement characterMovement;
    Inventory inventory;

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        inventory = GetComponent<Inventory>();
    }
    void Update()
    {
        if (interactedObject != null)
        {
            ProcessInteract();
        }
    }
   
    void ProcessInteract()
    {
        float distance = Vector3.Distance(transform.position, interactedObject.transform.position);

        if (distance < interactRange)
        {
            interactedObject.Interact(inventory);
            characterMovement.Stop();
            ResetState();
        }
        else
        {
            characterMovement.SetDestination(interactedObject.transform.position);
        }
    }

    public void ResetState()
    {
        interactedObject = null;
    }
}
