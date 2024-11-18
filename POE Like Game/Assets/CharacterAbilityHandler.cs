using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[Serializable]
public class AbilityContainer
{
    public Ability ability;
    public float currentCooldown;

    public float CooldownNormalized
    { 
        get { return 1f - (currentCooldown / ability.cooldown);} 
    }

    public AbilityContainer(Ability ability)
    {
        this.ability = ability;
    }

    internal void Cooldown()
    {
        currentCooldown = ability.cooldown;
    }

    public void ReduceCooldown(float deltaTime)
    {
        if (currentCooldown > 0f)
        {
            currentCooldown -= deltaTime;
        }
    }
}

public class CharacterAbilityHandler : MonoBehaviour
{
    [SerializeField] Ability startingAbility;
    List<AbilityContainer> abilities;
    public UnityEvent<AbilityContainer, int> onAbilityChange;
    public UnityEvent<float, int> onCooldownUpdate;

    private void Start()
    {
        if (startingAbility != null)
        {
            AddAbility(startingAbility);
        }

    }
    private void Update()
    {
        ProcessCooldown();
    }

    private void ProcessCooldown()
    {
        for (int i = 0; i < abilities.Count; i++)
        {
            abilities[i].ReduceCooldown(Time.deltaTime);
            onCooldownUpdate?.Invoke(abilities[i].CooldownNormalized, i);
        }
    }

    private void AddAbility(Ability abilityToAdd)
    {
        if (abilities == null)
        {
            abilities = new List<AbilityContainer>();
        }

        AbilityContainer abilityContainer = new AbilityContainer(abilityToAdd);
        abilities.Add(abilityContainer);
        onAbilityChange?.Invoke(abilityContainer, abilities.Count - 1);
    }
    public void ActivateAbility(AbilityContainer ability)
    {
        if (ability.currentCooldown > 0f) { return; }
        ability.Cooldown();

    }
    public void ActivateAbility(int abilityID)
    {
        if (abilities == null || abilities.Count == 0)
        {
            // Debug.LogError("No abilities available to activate.");
            return;
        }

        if (abilityID < 0 || abilityID >= abilities.Count)
        {
            // Debug.LogError($"Invalid abilityID: {abilityID}. Must be between 0 and {abilities.Count - 1}.");
            return;
        }

        // Debug.Log($"Activating ability with ID: {abilityID}");
        AbilityContainer abilityContainer = abilities[abilityID];
        ActivateAbility(abilityContainer);
    }




}
