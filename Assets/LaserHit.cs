using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHit : MonoBehaviour
{
    GameObject wizard;
    public float damage;
    public float lifetime = 3;
    public Animator laserAnim;

    private void FixedUpdate()
    {

        wizard = GameObject.Find("Player");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player") && lifetime < 0.6f && lifetime > 0.3f)
        {
            wizard.GetComponent<HealthManagement>().TakeDamage(damage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && lifetime < 0.6f && lifetime > 0.3f)
        {
            wizard.GetComponent<HealthManagement>().TakeDamage(damage);
        }
    }
}
