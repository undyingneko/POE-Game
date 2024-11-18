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
  
    public bool AttackCheck()
    {
        if (attackHandler.CheckAttack() == false) { return false; }
        return interactInput.attackTarget != null;
    }




  
}
