using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RespawnManager : MonoBehaviour
{
    GameObject player;
    BoxCollider2D RespawnTrigger;
    public GameObject respawnPoint;
    GameObject spikes;


    private void Start()
    {
        player = GameObject.Find("Player");
        RespawnTrigger = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spikes.GetComponent<damage>().lastRespawnPoint = respawnPoint;
        respawnPoint.SetActive(true);
    }
    
    
    private void FixedUpdate()
    {
        spikes = GameObject.FindGameObjectWithTag("spikes");

        if (spikes.GetComponent<damage>().lastRespawnPoint != respawnPoint)
        {
            respawnPoint.SetActive(false);
        }
    }
}


