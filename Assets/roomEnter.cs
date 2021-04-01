using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomEnter : MonoBehaviour
{
    public Transform roomEntryPoint;
    GameObject player;
    public Transform thisObject;
    Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > transform.position.x)
        {
            thisObject.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            thisObject.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        playerRB = player.GetComponent<Rigidbody2D>();
        playerRB.position = new Vector2(roomEntryPoint.position.x, roomEntryPoint.position.y);
        playerRB.velocity = new Vector2(0, 0);
    }
}
