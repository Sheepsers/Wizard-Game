using System;
using UnityEngine;

public class animation : MonoBehaviour
{
    public Animator attackAnim;
    public Transform attackPos;
    public Transform player;
    Vector2 playerPos;
    bool isAnimating;

    // Update is called once per frame
    void Update()
    {
        if (this.attackAnim.GetCurrentAnimatorStateInfo(0).IsTag("1"))
        {
            isAnimating = true;
        }
        else
        {
            isAnimating = false;
        }

        if (Input.GetKey("j") && !Input.GetKey("w") && !Input.GetKey("s") && !isAnimating)
        {
            Attack();
        }
        
        if(Input.GetKey("j") && Input.GetKey("w") && !Input.GetKey("s") && !isAnimating)
        {
            AttackUp();
        }

        if (Input.GetKey("j") && Input.GetKey("s") && !Input.GetKey("w") && !isAnimating)
        {
            AttackDown();
        }
    }

    void AttackDown()
    {
        attackAnim.SetTrigger("AttackDown");
    }

    void AttackUp()
    {
        attackAnim.SetTrigger("AttackUp");
    }

    void Attack()
    {
        attackAnim.SetTrigger("Attack");
    }
}
