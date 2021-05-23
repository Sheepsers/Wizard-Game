using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    //Testing to see if this shows up in the repository
    public float speed;
    public float jump;
    float moveVelocity;
    public Rigidbody2D rb;
    public Animator anim;
    bool isJumping;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float hangTime;
    float hangCounter;
    public SpriteRenderer player;
    public float dashSpeed;
    public Vector2 respawnPoint;
    public float deathHeight;
    public float dashTime;
    float dashCounter;
    bool isDashing;
    public float dashCooldown;
    public Vector2 offset;
    public Transform dashPos;
    public Animator anim3;
    Vector3 startingPosition;
    float dashDistance;
    public GameObject screenflash;
    public BoxCollider2D Collider;
    public bool doubleJump = false;
    bool canDoubleJump = false;
    public GameObject Camera;
    public GameObject dashParticles;
    public Vector3 particleOffset;
    public GameObject audioManager;
    

    //Grounded Vars

    public bool isGrounded;



    private void FixedUpdate()
    {

        if(!player.flipX)
        {
            dashParticles.transform.position = player.transform.position - particleOffset;
            dashParticles.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            dashParticles.transform.eulerAngles = new Vector3(0, 0, 0);
            dashParticles.transform.position = player.transform.position + particleOffset;
        }

        if (isGrounded && doubleJump)
        {
            canDoubleJump = true;
        }

        if (!isDashing && Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
        }
        else if (!isDashing)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
        }
        if (dashCooldown > 0)
        {
            dashCooldown -= Time.deltaTime;
        }
        else
        {
            dashCooldown = 0;
        }

        if (isDashing && player.flipX)
        {
            rb.velocity = new Vector2(-dashSpeed, 0);
        }
        else if (isDashing && !player.flipX)
        {
            rb.velocity = new Vector2(dashSpeed, 0);
        }



    }



    void Update()
    {

        if (isDashing)
        {            
            Collider.size = new Vector2(.28f, .28f);
            anim.SetBool("isDashing", true);
            screenflash.SetActive(true);
        }
        else
        {
 
            Collider.size = new Vector2(0.3295898f, 0.5724626f);
            anim.SetBool("isDashing", false);
            screenflash.SetActive(false);
        }




        //Dash Detection
        if (Input.GetButtonDown("Dash") && dashCooldown == 0)
        {
            GameObject.Find("Audio Manager").GetComponent<audiomanager>().Play("PlayerJump");
            dashParticles.GetComponent<ParticleSystem>().Play();
            Camera.GetComponent<ScreenShake>().StartShake(.1f, .1f);
            dashCounter = dashTime;
            dashCooldown = 0.7f;
        }

        if (Input.GetButtonUp("Left") || Input.GetButtonUp("Down"))
        {
            moveVelocity = 0f;
        }

        if (dashCounter > 0)
        {
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 3;
        }


        if (dashCounter > 0)
        {
            isDashing = true;
        }
        else
        {
            isDashing = false;
        }



        if (isGrounded)
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }

        

        //Check if Grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        //Jumping
        if(Input.GetButtonDown("Jump") && !isGrounded && canDoubleJump)
        {
            Jump();
            canDoubleJump = false;
        }
        
        
        if (Input.GetButtonDown("Jump") && hangCounter > 0f)
        {
            if (!isJumping)
            {
                 Jump();
            }
        }

        if (Input.GetButtonUp("Jump") && isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
        }

        //Left Right Movement
        if (Input.GetAxisRaw("Horizontal") < 0 && !Input.GetButton("Dash"))
        {
            moveVelocity = -speed;
        }


        if (Input.GetAxisRaw("Horizontal") > 0 && !Input.GetButton("Dash"))
        {
            moveVelocity = speed;
        }

        if (!isGrounded && rb.velocity.y > 0)
        {
            isJumping = true;
            anim.SetBool("isJumping", true);
        }
        if(rb.velocity.y <= 0)
        {
            isJumping = false;
            anim.SetBool("isJumping", false);
        }

        if (!isGrounded && !isJumping)
        {
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }
        if (Input.GetAxisRaw("Horizontal") > 0 && !isDashing)
        {
            dashPos.position = rb.position;
            player.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && !isDashing)
        {
            dashPos.position = rb.position;
            player.flipX = true;
        }
        if (isGrounded)
        {
            anim.SetBool("isGrounded", true);
        }
        else
        {
            anim.SetBool("isGrounded", false);
        }

        if (rb.transform.position.y < deathHeight)
        {
            transform.position = new Vector2(respawnPoint.x, respawnPoint.y);
        }

        offset = groundCheck.position;

    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jump);
    }

    void particlesOff()
    {
        dashParticles.SetActive(false);
    }
}