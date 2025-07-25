using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public ValuePool GetLifePool();
    public void TakeDamage(int damage);
}
