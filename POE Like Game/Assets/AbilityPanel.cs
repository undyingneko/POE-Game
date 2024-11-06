using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPanel : MonoBehaviour
{
    public void ActivateAbility(int abilitySlot)
    {
        Debug.Log("Activated ability Num: " + abilitySlot.ToString());
    }
    
    public void ActivatePotion(int potionSlot)
    {
        Debug.Log("Activated potion num: " + potionSlot.ToString());
    }
}


