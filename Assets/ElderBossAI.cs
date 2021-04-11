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


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
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

        if(playerDistance < 2 && playerDistance > 0|| playerDistance > -2 && playerDistance < 0)
        {
            rb.velocity = new Vector2(0, 0);
            if (!isAttacking)
            {
                bossAnim.SetTrigger("MeleeAttack");
                attackTimer = attackCooldown;
            }
        }

            if (attackTimer > 0)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
            attackTimer = 0;
        }

        if (playerDistance < 7 && playerDistance > 6 && !isAttacking || playerDistance > -7 && playerDistance < -6 && !isAttacking)
        {
            isAttacking = true;
            attackTimer = attackCooldown;
            checkForAttack();
        }

        if (playerDistance > 1)
        {
            boss.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(playerDistance < 1)
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

        if (playerDistance < 6 && playerDistance > 1)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (playerDistance > -6 && playerDistance < -1)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        if (playerDistance > 6 && playerDistance < 7)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);       
        }
        else if(playerDistance > 7 && !isAttacking)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }


        if (playerDistance > -7 && playerDistance < -6)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if (playerDistance < -7 && !isAttacking)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

        }

    }
        public void TakeDamage()
    {
        Debug.Log("Ouch");
    }
}
