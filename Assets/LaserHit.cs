using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHit : MonoBehaviour
{
    GameObject Player;
    public float damage;
    public float lifetime = 3;
    public Animator laserAnim;

    private void FixedUpdate()
    {

        Player = GameObject.Find("Player");
        lifetime -= Time.deltaTime;
        if(lifetime < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if(lifetime < 0.8f)
        {
            laserAnim.SetTrigger("Fire");
        }
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(lifetime < 0.8)
        {
            Player.GetComponent<HealthManagement>().TakeDamage(damage);
        }
    }

    private void OnTriggerStay2D(Collider2D player)
    {
        if (lifetime < 0.8)
        {
            Player.GetComponent<HealthManagement>().TakeDamage(damage);
        }
    }

}
