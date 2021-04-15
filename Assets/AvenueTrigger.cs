using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvenueTrigger : MonoBehaviour
{
    public GameObject AVAtext;

    
    private void OnTriggerEnter2D(Collider2D player)
    {
        AVAtext.SetActive(true);
        Invoke("Disable", 2f);
    }

    private void Disable()
    {
        AVAtext.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
