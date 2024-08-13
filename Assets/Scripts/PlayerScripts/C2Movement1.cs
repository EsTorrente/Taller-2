using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C2Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float wallSlideSpeed;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    private Health health;

    // PLATAFORMITAS
    private Transform currentPlatform;
    private Vector3 previousPlatformPosition;

    private void Awake()
    {
        //agarrar referencias del rigid body y animator
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        health = FindObjectOfType<Health>();
    }

    private void Update()
    {
        // deshabilitar controles
        //if (Health.Dead)
        //{
        //body.velocity = Vector2.zero;
        // return;
        //}

        //MOVIMIENTO HORIZONTAL
        horizontalInput = Input.GetAxis("Horizontal");

        //voltear sprite dependiendo de dirección
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        //PERÍMETROS DE ANIMACIÓN
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("Grounded", isGrounded());
        anim.SetBool("Wall", onWall() && !isGrounded());

        //logica de wall jump
        if (wallJumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                if (horizontalInput == 0)
                {
                    body.velocity = new Vector2(0, -wallSlideSpeed);
                }
                else
                {
                    body.velocity = Vector2.zero;
                }
            }
            else
                body.gravityScale = 3;

            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            wallJumpCooldown += Time.deltaTime;
    }


    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("Jump");
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return !onWall(); // && !Health.Dead;
    }

}