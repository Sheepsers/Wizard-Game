using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 20f;
    public float lifetime = 50f;
    public float life;
    public GameObject bullet;
    public Transform attackPoint;
    public float attackRange = 0.1f;
    public float damage = 1f;
    public LayerMask enemies;
    public bool Wall;
    public LayerMask walls;
    public GameObject hitSparks;

    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame       
    void Update()
    {
        Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemies);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemies);

        for (int i = 0; i < hitEnemies.Length; i++)
        {
            if (hitEnemies[i].GetComponent<enemyAI>())
            {
                hitEnemies[i].GetComponent<enemyAI>().TakeDamage(damage);
            }
            else if (hitEnemies[i].GetComponent<ElderBossAI>())
            {
                hitEnemies[i].GetComponent<ElderBossAI>().TakeDamage(damage);
            }
            

            Instantiate(hitSparks, attackPoint.position, attackPoint.rotation);
            Destroy(bullet);
        }

        if (lifetime <= 0)
        {
            Destroy(bullet);
        }
        Wall = Physics2D.OverlapCircle(attackPoint.position, 0.3f, walls);
        if (Wall)
        {
            Instantiate(hitSparks, attackPoint.position, attackPoint.rotation);
            Destroy(bullet);
        }
    
    }

    private void FixedUpdate()
    {
        lifetime -= Time.deltaTime;
    }
}
