using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public GameObject player;
    public float spikeDamage = 5f;
    GameObject respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        respawnPoint = GameObject.Find("Respawn Point");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        player.GetComponent<HealthManagement>().damageCooldown = 0;
        player.GetComponent<HealthManagement>().TakeDamage(spikeDamage);
        Invoke("ResetPlayer", 0.2f);
    }

    private void ResetPlayer()
    {
        player.transform.position = respawnPoint.transform.position;
    }
}
