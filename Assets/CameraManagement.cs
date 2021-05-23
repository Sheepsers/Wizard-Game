using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManagement : MonoBehaviour
{
    public Transform player;
    public CinemachineConfiner confiner;
    public GameObject currentRoom;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentRoom = GameObject.Find("Boundary");
        confiner.m_BoundingShape2D = currentRoom.GetComponent<PolygonCollider2D>();
    }
}
