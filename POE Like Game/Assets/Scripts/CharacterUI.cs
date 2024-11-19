
using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    Character character;
    [SerializeField] UIPoolBar hpBar;
    [SerializeField] UIPoolBar energyBar;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Update()
    {
        hpBar.Show(character.lifePool);
        energyBar.Show(character.energyPool);
    }
    

   
}
