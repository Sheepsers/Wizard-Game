using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomEnterUp : MonoBehaviour
{
    public Transform roomEntryPoint;
    public Transform roomEntryPoint2;
    GameObject player;
    public Transform thisObject;
    Rigidbody2D playerRB;
    SpriteRenderer playerSP;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    private void OnTriggerEnter2D(Collider2D player)
    {
        playerRB = player.GetComponent<Rigidbody2D>();
        playerSP = player.GetComponent<SpriteRenderer>();
        if (playerSP.flipX)
        {
            thisObject.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            thisObject.eulerAngles = new Vector3(0, 0, 0);
        }

        if (player.transform.position.y > transform.position.y)
        {
            playerRB.position = new Vector2(roomEntryPoint.position.x, roomEntryPoint.position.y);
        }
        else
        {
            playerRB.position = new Vector2(roomEntryPoint2.position.x, roomEntryPoint2.position.y);
        }
        
        playerRB.velocity = new Vector2(0, 0);
    }
}
