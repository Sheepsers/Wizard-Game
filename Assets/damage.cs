using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public GameObject player;
    public float spikeDamage = 5f;
    public GameObject lastRespawnPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<HealthManagement>().damageCooldown = 0;
            player.GetComponent<HealthManagement>().TakeDamage(spikeDamage);
            player.GetComponent<playerMove>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Invoke("ResetPlayer", 0.2f);
        }

    }

    private void ResetPlayer()
    {
        player.transform.position = lastRespawnPoint.transform.position;
        player.GetComponent<playerMove>().enabled = true;
    }
}
