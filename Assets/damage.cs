using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public GameObject player;
    public float spikeDamage = 5f;

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
        player.GetComponent<HealthManagement>().TakeDamage(spikeDamage);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        player.GetComponent<HealthManagement>().TakeDamage(spikeDamage);
    }
}
