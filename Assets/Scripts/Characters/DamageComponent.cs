using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] string TargetTag;
    public void Damage(IHurtable target)
    {
        if(target.Tag == TargetTag)
            target.GetHurt(damage);
    }
}
