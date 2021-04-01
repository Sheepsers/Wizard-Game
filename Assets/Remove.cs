using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Invoke("RemoveText", 2f);
    }

    private void RemoveText()
    {
        this.gameObject.SetActive(false);
    }
}