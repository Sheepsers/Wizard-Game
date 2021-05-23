using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public Transform Player;
    public Rigidbody2D rb;
    public Transform Enemy;
    public float detectRange;
    float playerDistance;
    public float Speed;
    bool inRange;
    public float verticalDetectRange;
    public SpriteRenderer enemySP;
    float verticalPlayerDistance;
    float stunTimer;
    public Animator enemyAnim;

    public float health;
    public float kb;
    bool isStunned;
    public float stunTime;
    public GameObject yourself;
    public GameObject playerObj;
    public LayerMask PlayerMask;
    public Transform attackPoint;
    public float attackRange;
    public float damage;
    public float attackCooldown = 2;
    public Transform aircheck;
    bool forwardisSafe;
    public LayerMask groundmask;
    public GameObject MyBoundary;
    GameObject ActiveBoundary;
    bool isActive;
    public LayerMask enemyLayers;

    // Update is called once per frame
    private void FixedUpdate()
    {
        

        if (stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;
        }
        if(attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }
        if(attackCooldown < 0)
        {
            attackCooldown = 0;
        }

    }
    void Update()
    {
        ActiveBoundary = GameObject.Find("Boundary");

        if(ActiveBoundary == MyBoundary)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }

        if (isActive)
        {
            ActiveUpdate();
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
    
    void ActiveUpdate()
    {
        forwardisSafe = Physics2D.OverlapCircle(aircheck.position, 0.2f, groundmask) && !Physics2D.OverlapCircle(attackPoint.position, 0.1f, enemyLayers);

        if (!forwardisSafe)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        playerObj = GameObject.Find("Player");

        Player = playerObj.GetComponent<Transform>();

        if (rb.velocity.x > 0.5f || rb.velocity.x < -0.5f)
        {
            enemyAnim.SetBool("isMoving", true);
        }
        else
        {
            enemyAnim.SetBool("isMoving", false);
        }

        if (health == 0)
        {
            Destroy(yourself);
        }

        if (stunTimer > 0)
        {
            isStunned = true;
        }
        else
        {
            isStunned = false;
        }

        if (Enemy.position.x - Player.position.x < detectRange && Enemy.position.x - Player.position.x > -detectRange && Player.position.y - Enemy.position.y < verticalDetectRange && !isStunned)
        {
            playerDistance = Enemy.position.x - Player.position.x;
            verticalPlayerDistance = Player.position.x - Enemy.position.y;
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        if (playerDistance < 0 && inRange)
        {
            Enemy.eulerAngles = new Vector3(0, 180, 0);

            if (!forwardisSafe)
            {
                rb.velocity = new Vector2(0, 0);
            }
            else
            {
                rb.velocity = new Vector2(Speed, rb.velocity.y);
            }
        }
    

        if (playerDistance > 0 && inRange)
        {
            Enemy.eulerAngles = new Vector3(0, 0, 0);

            if (!forwardisSafe)
            {
                rb.velocity = new Vector2(0, 0);
            }
            else
            {
                rb.velocity = new Vector2(-Speed, rb.velocity.y);
            }
        }
    
    
        if (!inRange)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (playerDistance > -0.7 && playerDistance < 0.7 && inRange && !isStunned)
        {
            if (attackCooldown == 0)
            {
                enemyAnim.SetTrigger("Attack");
                attackCooldown = 1;
                Invoke("Attack", 0.6f);
            }
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (this.enemyAnim.GetCurrentAnimatorStateInfo(0).IsName("EnemyAttack"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }

    public void TakeDamage(float damage)
    {
        if (enemySP.flipX)
        {
            health -= damage;
            rb.AddForce(-transform.right * kb);
            stunTimer = stunTime;
        }
        else
        {
            health -= damage;
            rb.AddForce(transform.right * kb);
            stunTimer = stunTime;
        }
    }
    void Attack()
    {
        Physics2D.OverlapCircleAll(attackPoint.position, attackRange, PlayerMask);

        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, PlayerMask);

        for (int i = 0; i < hitPlayers.Length; i++)
        {
            hitPlayers[i].GetComponent<HealthManagement>().TakeDamage(damage);
        }

    }
}
