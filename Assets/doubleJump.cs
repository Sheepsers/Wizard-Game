using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleJump : MonoBehaviour
{
    public GameObject player;
    public GameObject DoubleJump;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D player)
    {
        player.GetComponent<playerMove>().doubleJump = true;
        DoubleJump.SetActive(true);
        Destroy(this.gameObject);
    }


}
