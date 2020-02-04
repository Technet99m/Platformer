using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetController))]
public class MovementController : MonoBehaviour
{
    TargetController tc;
    Rigidbody2D rb;
    [SerializeField] float speed;

    void Start()
    {
        tc = GetComponent<TargetController>();
        rb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        rb.velocity = Vector2.right * tc.dirX * speed;
    }
}
