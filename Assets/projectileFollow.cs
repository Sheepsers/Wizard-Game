﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileFollow : MonoBehaviour
{
    public Transform projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = projectile.position;
    }
}
