 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform player;
    public BoxCollider2D cameraBox;

    // Start is called before the first frame update
    void Start()
    {
        cameraBox = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {        
        if (GameObject.Find("Boundary"))
        {
            transform.position = new Vector3(Mathf.Clamp(player.position.x, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.min.x + cameraBox.size.x / 2, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.max.x - cameraBox.size.x / 2),
                                             Mathf.Clamp(player.position.y, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.min.y + cameraBox.size.y / 2, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.max.y - cameraBox.size.y / 2),
                                             transform.position.z);
        }
    }
}
