
using UnityEngine;

public class DestructableObject : MonoBehaviour, IDamageable
{
    public ValuePool GetLifePool()
    {
        return null;
    }

    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
    }

  
}
