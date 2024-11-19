using System.Collections;
using System.Collections.Generic;
using CharacterCommand;
using UnityEngine;

public class InteractHandler : MonoBehaviour, ICommandHanddle
{
    [SerializeField] float interactRange = 3.5f;
    CharacterMovement characterMovement;
    Character character;

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        character = GetComponent<Character>();
    }


    public void ProcessCommand(Command command)
    {
        float distance = Vector3.Distance(transform.position, command.target.transform.position);

        if (distance < interactRange)
        {
            command.target.GetComponent<InteractableObject>().Interact(character);
            characterMovement.Stop();
            command.isComplete = true;
        }
        else
        {
            characterMovement.SetDestination(command.target.transform.position);
        }
    }
}
