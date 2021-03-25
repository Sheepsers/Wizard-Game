using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public GameObject player;
    public float spikeDamage = 5f;
    public GameObject lastRespawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<HealthManagement>().damageCooldown = 0;
            player.GetComponent<HealthManagement>().TakeDamage(spikeDamage);
            Invoke("ResetPlayer", 0.2f);
        }

    }

    private void ResetPlayer()
    {
        player.transform.position = lastRespawnPoint.transform.position;
    }
}
