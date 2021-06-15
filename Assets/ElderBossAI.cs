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
    public Transform summonPoint1;
    public Transform summonPoint2;
    public Transform summonPoint3;
    public Transform summonPoint4;
    public GameObject laser;
    public float meeleeDamage;
    public LayerMask PlayerMask;
    public Transform attackPoint;
    public float mintpdistance;
    public float maxtpdistance;
    public float maxhealth;
    public GameObject door;
    public GameObject door2;
    public Transform LaserPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        health = maxhealth;
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
        if(health == 0)
        {
            door.SetActive(false);
            door2.SetActive(false);
            Destroy(this.gameObject);
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
            bossAnim.SetTrigger("Leave");
            teleportX = Random.Range(bossArena.transform.position.x - mintpdistance, bossArena.transform.position.x + maxtpdistance);
            Invoke("Leave", 1f);
        }

        if (playerDistance < 1 && playerDistance > 0|| playerDistance > -1 && playerDistance < 0)
        {
            rb.velocity = new Vector2(0, 0);
            if (!attackCooldownActive)
            {
                bossAnim.SetTrigger("MeleeAttack");
                Invoke("meeleeAttack", 0.5f);
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

        Invoke("activate",0.3f);

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
        Invoke("summonLasers", 1f);
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

    void activate()
    {
        if (activeRoom.transform.position == bossArena.transform.position)
        {
            bossArenaActive = true;
        }
        else
        {
            bossArenaActive = false;
        }
    }

    void summonLasers()
    {
        summonPoint1.position = new Vector3(Random.Range(0, 3), LaserPoint.transform.position.y, 0) + new Vector3(player.transform.position.x,0,0);
        summonPoint2.position = new Vector3(Random.Range(3, 7), LaserPoint.transform.position.y, 0) + new Vector3(player.transform.position.x, 0, 0);
        summonPoint3.position = new Vector3(Random.Range(0, -3), LaserPoint.transform.position.y, 0) + new Vector3(player.transform.position.x, 0, 0);
        summonPoint4.position = new Vector3(Random.Range(-3, -7), LaserPoint.transform.position.y, 0) + new Vector3(player.transform.position.x, 0, 0);

        summonPoint1.eulerAngles = new Vector3(0, 0, Random.Range(-15, 15));
        summonPoint2.eulerAngles = new Vector3(0, 0, Random.Range(-15, 15));
        summonPoint3.eulerAngles = new Vector3(0, 0, Random.Range(-15, 15));
        summonPoint4.eulerAngles = new Vector3(0, 0, Random.Range(-15, 15));

        Instantiate(laser, summonPoint1.position, summonPoint1.rotation);
        Instantiate(laser, summonPoint2.position, summonPoint2.rotation);
        Instantiate(laser, summonPoint3.position, summonPoint3.rotation);
        Instantiate(laser, summonPoint4.position, summonPoint4.rotation);
    }

    void meeleeAttack()
    {
        Physics2D.OverlapCircleAll(attackPoint.position, 0.7f, PlayerMask);

        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, 0.7f, PlayerMask);

        for (int i = 0; i < hitPlayers.Length; i++)
        {
            hitPlayers[i].GetComponent<HealthManagement>().TakeDamage(meeleeDamage);
        }
    }
    void Leave()
    {
        transform.position = new Vector3(teleportX, transform.position.y, transform.position.z);
    }
}
