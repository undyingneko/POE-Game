using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CharacterDefeatHandler : MonoBehaviour
{
    NavMeshAgent agent;
    AIEnemy aiEnemy;
    Collider objectCollider;
    AttackInput attackInput;
    InteractInput interactInput;
    PlayerCharacterInput playerCharacterInput;
    CharacterMovementInput movementInput;
    Character character;

    [SerializeField] bool player = false;
    [SerializeField] GameObject defeatedPanel;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        aiEnemy = GetComponent<AIEnemy>();
        objectCollider = GetComponent<Collider>();

        attackInput = GetComponent<AttackInput>();
        interactInput = GetComponent<InteractInput>();
        playerCharacterInput = GetComponent<PlayerCharacterInput>();
        movementInput = GetComponent<CharacterMovementInput>();
        character = GetComponent<Character>();
    }

    public void Defeated()
    {
        if (agent != null && agent.isOnNavMesh && agent.enabled)
        {
            agent.isStopped = true;
            agent.enabled = false;
        }
        SetState(false);
    }

    internal void Respawn()
    {
        if (agent != null && NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
        {
            transform.position = hit.position; // Place character on the nearest NavMesh point
            agent.enabled = true;
            agent.isStopped = false;
        }
        SetState(true);
    }
    void SetState(bool state)
    {
        objectCollider.enabled = state;

        //AI part
        if (aiEnemy != null)
        {
            aiEnemy.enabled = state;
        }

        //player part
        if (attackInput != null)
        {
            attackInput.enabled = state;
        }

        if (interactInput != null)
        {
            interactInput.enabled = state;
        }

        if (playerCharacterInput != null)
        {
            playerCharacterInput.enabled = state;
        }

        if (movementInput != null)
        {
            movementInput.enabled = state;
        }
        if (defeatedPanel != null)
        {
            defeatedPanel.SetActive(!state);
        }
        if (state == true) //call only on respawn
        {
            if (character != null)
            {
                character.Restore();
            }
        }
       
    }
}