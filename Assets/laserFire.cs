using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserFire : MonoBehaviour
{
    Animator LaserAnim;
    public LayerMask playerLayer;
    BoxCollider2D laserCollider;
    public float windup = 1;

    // Start is called before the first frame update

    private void Awake()
    {
        LaserAnim = GetComponent<Animator>();
        laserCollider = GetComponent<BoxCollider2D>();
        if (windup < 0)
        {
            LaserAnim.SetTrigger("Fire");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        windup -= Time.deltaTime;
    }
}
