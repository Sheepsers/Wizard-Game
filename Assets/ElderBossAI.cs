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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        activeRoom = GameObject.Find("Boundary");

        if(activeRoom.transform.position == bossArena.transform.position)
        {
            bossArenaActive = true;
        }
        else
        {
            bossArenaActive = false;
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

        if (playerDistance > 1 && !isAttacking)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (playerDistance < 1 && !isAttacking)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

        }

    }
        public void TakeDamage()
    {
        Debug.Log("Ouch");
    }
}
