using System;
using System.Collections;
using System.Collections.Generic;
using CharacterCommand;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CanMoveState))]
public class CharacterMovement : MonoBehaviour, ICommandHanddle
{
    NavMeshAgent agent;
    Character character;
    [SerializeField] float default_MoveSpeed = 3.5f;
    float current_MoveSpeed;
    StatsValue moveSpeed;
    CanMoveState canMoveState;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<Character>();
        canMoveState = GetComponent<CanMoveState>();
    }
    private void Start()
    {
        moveSpeed = character.GetStatsValue(Statistic.MoveSpeed);
        UpdateMoveSpeed();
    }
    private void UpdateMoveSpeed()
    {
        agent.speed = default_MoveSpeed * moveSpeed.float_value;
    }
    private void Update()
    {
        if (current_MoveSpeed != moveSpeed.float_value)
        {
            current_MoveSpeed = moveSpeed.float_value;
            UpdateMoveSpeed();
        }
    }

    public void SetDestination(Vector3 destinationPosition)
    {
        if (canMoveState.Check() == true)
        {
            agent.isStopped = false;
            agent.SetDestination(destinationPosition);
        }
    }

    internal void Stop()
    {
        
        agent.isStopped = true;
    }

    public void ProcessCommand(Command command)
    {
      SetDestination(command.worldPoint);
    }
}
