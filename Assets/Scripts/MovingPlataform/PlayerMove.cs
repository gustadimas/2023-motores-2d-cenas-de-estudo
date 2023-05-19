using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D coll;

    float dirX;

    [SerializeField] float moveSpeed, jumpForce;

    [SerializeField] LayerMask jumpableGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (dirX > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        else if (dirX < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
