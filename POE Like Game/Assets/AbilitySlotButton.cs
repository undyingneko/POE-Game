using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySlotButton : MonoBehaviour
{
    [SerializeField] Image abilityIcon;


    public void UpdateAbility(AbilityContainer ability)
    {
        abilityIcon.sprite = ability.ability.icon;
    }

    internal void UpdateCooldown(float cooldownNormalized)
    {
        abilityIcon.fillAmount = cooldownNormalized;
    }
}
