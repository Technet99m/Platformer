using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthComponent : MonoBehaviour, IHurtable
{
    [SerializeField] float MaxHealth;
    private float health;
    string IHurtable.Tag
    {
        get { return tag; }
    }
    public void GetHurt(float damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }
    public abstract void Die();
}
public interface IHurtable
{
    string Tag { get; }
    void GetHurt(float damage);

    void Die();
}
