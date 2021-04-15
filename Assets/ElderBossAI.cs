using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElderBossAI : MonoBehaviour
{
    GameObject player;
    public GameObject bossArena;
    bool bossArenaActive;
    GameObject activeRoom;
    public Animator bossAnim;
    public Rigidbody2D rb;
    float playerDistance;
    float verticalPlayerDistance;
    public GameObject boss;
    bool isAttacking;
    public float speed = 5f;
    public float attackCooldown;
    float attackTimer;
    float randomAttack;
    bool isAgainstWall;
    public Transform wallcheck;
    public LayerMask groundLayer;
    public float health;
    float teleportX;
    float attackTime;
    bool attackCooldownActive;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        health = 50f;
    }

    private void FixedUpdate()
    {
        isAgainstWall = Physics2D.OverlapCircle(wallcheck.position, 0.3f, groundLayer);

        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
       
        if (attackTime > 0f)
        {
            attackTime -= Time.deltaTime;
        }

        if (bossArenaActive)
        {
            FollowPlayer();
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (isAgainstWall)
        {
            teleportX = Random.Range(-34, -43);
            transform.position = new Vector3(teleportX, transform.position.y, transform.position.z);
        }

        if (playerDistance < 1 && playerDistance > 0|| playerDistance > -1 && playerDistance < 0)
        {
            rb.velocity = new Vector2(0, 0);
            if (!attackCooldownActive)
            {
                bossAnim.SetTrigger("MeleeAttack");
                attackTime = 0.4f;
                attackTimer = attackCooldown;
            }
        }

        if (attackTimer > 0f)
        {
            attackCooldownActive = true;
        }
        else
        {
            attackCooldownActive = false;
            attackTimer = 0f;
        }

        if (attackTime > 0f)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
            attackTime = 0f;
        }

        if (playerDistance < 7 && playerDistance > 1.5f && !attackCooldownActive || playerDistance > -7 && playerDistance < -1.5f && !attackCooldownActive)
        {
            attackTime = 1f;
            attackTimer = attackCooldown;
            checkForAttack();
        }

        if (playerDistance > 1)
        {
            boss.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(playerDistance < -1)
        {
            boss.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        activeRoom = GameObject.Find("Boundary");

        if (activeRoom.transform.position == bossArena.transform.position)
        {
            bossArenaActive = true;
        }
        else
        {
            bossArenaActive = false;
        }

    }

    void checkForAttack()
    {
        randomAttack = Random.Range(1, 5);
        if(randomAttack > 1)
        {
            Attack();
        }
    }
    void Attack()
    {
        bossAnim.SetTrigger("Attack");
    }

    void FollowPlayer()
    {
        if (rb.velocity.x > 0.5f || rb.velocity.x < -0.5f)
        {
            bossAnim.SetBool("isMoving", true);
        }
        else
        {
            bossAnim.SetBool("isMoving", false);
        }
        playerDistance = boss.transform.position.x - player.transform.position.x;
        verticalPlayerDistance = boss.transform.position.x - player.transform.position.y;

        if (playerDistance < 6 && playerDistance > 1 && !isAttacking)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (playerDistance > -6 && playerDistance < -1 && !isAttacking)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        if (playerDistance > 6 && playerDistance < 7 && !isAttacking)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);       
        }
        else if(playerDistance > 7 && !isAttacking && !isAttacking)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }


        if (playerDistance > -7 && playerDistance < -6 && !isAttacking)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if (playerDistance < -7 && !isAttacking && !isAttacking)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

        }

    }
        public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
