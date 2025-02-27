using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private CapsuleCollider2D bodyCollider;
    private BoxCollider2D feetCollider2D;
    private float gravityScaleAtStart;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float climbSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        feetCollider2D = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void Run()
    {
        Vector3 playerVelocity = new Vector2(moveInput.x * speed, rb.velocity.y);
        rb.velocity = playerVelocity;

        bool playerHasHorizoltalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("IsRunning", playerHasHorizoltalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizoltalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizoltalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    void OnJump(InputValue value)
    {
        if (!feetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
            return;
        if (value.isPressed)
        {
            rb.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void ClimbLadder()
    {
        if (!feetCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            rb.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("IsClimbing", false);
            return;
        }
            
        Vector2 climbVelocity = new Vector2(rb.velocity.x, moveInput.y * climbSpeed);
        rb.velocity = climbVelocity;
        rb.gravityScale = 0f;

        bool playerHasHorizoltalSpeed = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("IsClimbing", playerHasHorizoltalSpeed);
    }

    
}
