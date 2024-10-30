using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    Character character;
    [SerializeField] UIPoolBar hpBar;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Update()
    {
        hpBar.Show(character.lifePool);
    }
    

   
}
