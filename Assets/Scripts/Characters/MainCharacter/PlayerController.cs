using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed, runSpeed, jumpForce;
    [SerializeField] Transform legs;
    [SerializeField] LayerMask mask;

    bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }


    private void Update()
    {
        if (isGrounded)
            Jump();
        else
            CheckGround();

        HorizontalMovement();
    }

    void CheckGround()
    {
        var hit = Physics2D.Raycast(legs.position, Vector2.down, 0.01f, mask.value);
        if(hit)
        {
            isGrounded = true;
        }
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            isGrounded = false;
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
    void HorizontalMovement()
    {
        float dir = 0;
        if (Input.GetKey(KeyCode.D))
        {
            dir += 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir -= 1f;
        }
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
            rb.velocity = new Vector2(dir * runSpeed, rb.velocity.y);
        else
            rb.velocity = new Vector2(dir * speed, rb.velocity.y);
    }

}
