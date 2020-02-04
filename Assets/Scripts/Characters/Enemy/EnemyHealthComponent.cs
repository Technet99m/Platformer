using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthComponent : HealthComponent
{
    public override void Die()
    {
        gameObject.SetActive(false);
    }
}
