using System;
using System.Collections;
using System.Collections.Generic;
using CharacterCommand;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    [SerializeField] AIAgentGroup aiGroup;
    CommandHandler commandHandler;



    [SerializeField] Character target;
    float timer = 4f;

    private void Awake()
    {
        commandHandler = GetComponent<CommandHandler>();
        if (commandHandler == null)
        {
            Debug.LogError($"CommandHandler is missing on {gameObject.name}");
        }
    }

    private void Start()
    {

        target = GameManager.instance.playerObject.GetComponent<Character>();
        aiGroup.Add(this);
    }

    private void OnDestroy()
    {
        if (aiGroup != null)
        {
            aiGroup.Remove(this);
        }
    }

    internal void UpdateAgent(GameObject targetToAttack)
    {
        if (commandHandler == null)
        {
            // Debug.LogError("CommandHandler  is null.");
            return;
        }
        if (targetToAttack == null)
        {
            // Debug.LogError("targetToAttack is null.");
            return;
        }
        // if (target == null || target.isDead)
        // {
        //     return;
        // }

        timer -= Time.deltaTime;

        if (timer < 0f)
        {
            timer = 4f;

            commandHandler.SetCommand(new Command(CommandType.Attack, targetToAttack));
        }
    }
}





