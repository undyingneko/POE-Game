using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUi : MonoBehaviour
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
