using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DamageComponent))]
public class AttackController : MonoBehaviour
{
    Rigidbody2D rb;
    DamageComponent dc;
    float dir;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask mask;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dc = GetComponent<DamageComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 0.1f)
            dir = Mathf.Sign(rb.velocity.x);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Strike();
        }
    }

    void Strike()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.right * dir, attackRange, mask.value);
        if(hit)
        {
            dc.Damage(hit.transform.GetComponent<HealthComponent>());
        }
    }
}
