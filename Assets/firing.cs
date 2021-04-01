using UnityEngine;

public class firing : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;
    public Animator attackAnim;
    bool isAnimating;
    public Transform attackPoint;
    public LayerMask enemies;


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

        if (Input.GetButton("Fire1") && !isAnimating)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(projectile, firePoint.position, firePoint.rotation);
    }
}
