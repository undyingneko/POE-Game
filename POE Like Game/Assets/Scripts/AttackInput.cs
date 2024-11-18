using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInput : MonoBehaviour
{
    InteractInput interactInput;
    AttackHandler attackHandler;
    private void Awake()
    {
        interactInput = GetComponent<InteractInput>();
        attackHandler = GetComponent<AttackHandler>();
    }

    public bool AttackCooldownCheck()
    {
        return attackHandler.CheckAttack();
    }


    public bool AttackTargertCheck()
    {
        return interactInput.attackTarget != null;
    }




  
}
