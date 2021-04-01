using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class secretReveal : MonoBehaviour
{
    public TilemapRenderer fakeWall;
    public CompositeCollider2D trigger;

    private void OnTriggerEnter2D(Collider2D player)
    {
        fakeWall.enabled = false;
    }
    private void OnTriggerExit2D(Collider2D player)
    {
        fakeWall.enabled = true;
    }
}
