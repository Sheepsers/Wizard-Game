using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    GameObject player;
    BoxCollider2D RespawnTrigger;
    public GameObject respawnPoint;


    private void Awake()
    {
        respawnPoint.SetActive(false);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        RespawnTrigger = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        respawnPoint.SetActive(true);
    }

}


