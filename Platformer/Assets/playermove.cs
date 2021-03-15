using System;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public bool isJumping;
    public Animator anim;
    public float moveSpeed;
    public Rigidbody2D rb;
    public float jumpForce;
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    float xInput, yInput;
    public float stopSpeed;
    public float deathHeight;
    public Vector2 respawnPoint;
    public float hangTime;
    private float hangCounter;
    public SpriteRenderer player;
    bool isGrounded2;
    public Transform groundCheck2;

    void Start()
    {
        
    }

    void Jump()
        //jumping
    
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    private void FixedUpdate()
    {
        //no bouncy bouncy
        xInput = Input.GetAxis("Horizontal");

        transform.Translate(xInput * moveSpeed, yInput * moveSpeed, 0);

        PlatformerMove();

    }

    private void PlatformerMove()
        //movement
    
    {
        rb.velocity = new Vector2(moveSpeed * xInput, rb.velocity.y);
    }

    void Update()
    {
        //ground checking
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        isGrounded2 = Physics2D.OverlapCircle(groundCheck2.position, 0.2f, groundLayer);

        //respawning
        if (rb.transform.position.y < deathHeight)
        {
            transform.position = new Vector2(respawnPoint.x, respawnPoint.y);
        }
        
        //better movement control
        if (Input.GetKeyUp("d") && Input.GetKeyUp("a"))
        {
            rb.velocity = new Vector2(rb.velocity.x * 0, rb.velocity.y);
        }

        if (isGrounded || isGrounded2)
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown("w") && !isJumping && hangCounter > 0f)
        {
            Jump();
        }
    
        if (Input.GetKeyUp("w") && isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
        }

        //Player flipping
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            player.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            player.flipX = true;
        }

        //animation switching

        if (!isGrounded && rb.velocity.y > 0)
        {
            isJumping = true;
            anim.SetBool("isJumping", true);
        }
        else
        {
            isJumping = false;
            anim.SetBool("isJumping", false);
        }

        if (!isGrounded && rb.velocity.y < 0)
        {
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }

    }
}
