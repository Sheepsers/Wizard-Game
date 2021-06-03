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
    Transform previousPos;


    private void Awake()
    {
        rb.velocity = transform.right * speed;
        previousPos = transform;
    }

    // Update is called once per frame       
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(180,0,0), -1f, enemies);

        if (hit)
        {
            if(hit.collider.gameObject.GetComponent<enemyAI>() != null)
            {
                hit.collider.gameObject.GetComponent<enemyAI>().TakeDamage(damage);
            }
            else if (hit.collider.gameObject.GetComponent<ElderBossAI>() != null)
            {
                hit.collider.gameObject.GetComponent<ElderBossAI>().TakeDamage(damage);
            }

            Instantiate(hitSparks, hit.point, attackPoint.rotation);
            Destroy(bullet);
        }

        previousPos = transform;

        if (lifetime <= 0)
        {
            Destroy(bullet);
        }
    }

    private void FixedUpdate()
    {
        lifetime -= Time.deltaTime;
    }
}
